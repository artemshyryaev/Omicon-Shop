using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.Checkout.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Checkout.Operations
{
    public class OrderOperations
    {
        IUserRepository userRepository;

        public OrderOperations(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddUserInformationToOrder(ref Order order, OrderInformationViewModel orderInformation)
        {
            var user = userRepository.GetUserByEmail(orderInformation.Email);

            if (user == null)
            {
                user = new User
                {
                    Email = orderInformation.Email
                };

                FillUserAddressProperties(orderInformation, ref user);
                FillUserPersonalInformationProperties(orderInformation, ref user);
            }

            order.User = user;
        }

        public void FillUserAddressProperties(OrderInformationViewModel model, ref User user)
        {
            UserAddress userAddress = new UserAddress()
            {
                Country = model.Country,
                City = model.City,
                Address = model.Address,
                Address2 = model.Address2,
                ZipCode = model.ZipCode,
                UserId = user.UserId
            };

            user.UserAddress = userAddress;
        }

        public void FillUserPersonalInformationProperties(OrderInformationViewModel model, ref User user)
        {
            UserPersonalInformation userPersonalInformation = new UserPersonalInformation()
            {
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
                UserId = user.UserId
            };

            user.UserPersonalInformation = userPersonalInformation;
        }

        public void AddOrderInformationToOrder(ref Order order, BasketViewModel basket, OrderInformationViewModel orderInformationViewModel)
        {
            order.Status = OrderStatuses.Pending;

            OrderInformation orderInformation = new OrderInformation()
            {
                Date = DateTime.Today,
                Total = basket.BasketTotal,
                Delivery = orderInformationViewModel.Delivery,
                Payment = orderInformationViewModel.Payment,
            };

            order.OrderInformation = orderInformation;
        }

        public void AddBasketLinesToOrder(BasketViewModel basket, ref Order order)
        {
            foreach (var el in basket.Lines)
            {
                var line = new BasketLine();
                line.Uom = el.Uom;
                line.Qty = el.Quantity;
                line.Product = el.Product;

                order.BasketLine.Add(line);
            }
        }
    }
}
