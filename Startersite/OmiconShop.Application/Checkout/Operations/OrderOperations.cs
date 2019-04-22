using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.Checkout.ViewModel;
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
        public void AddOrderInformationToOrder(ref Order order, BasketViewModel basket, OrderInformationViewModel orderInformation)
        {
            order = new Order();

            order.Status = OrderStatuses.Pending;
            order.OrderInformation.Date = DateTime.Today;
            order.OrderInformation.Total = basket.BasketTotal();
            order.OrderInformation.Delivery = orderInformation.Delivery;
            order.OrderInformation.Payment = orderInformation.Payment;

            order.User.UserAddress.Country = orderInformation.Country;
            order.User.UserAddress.City = orderInformation.City;
            order.User.UserAddress.Address = orderInformation.Address;
            order.User.UserAddress.Address2 = orderInformation.Address2;
            order.User.UserAddress.ZipCode = orderInformation.ZipCode;

            order.User.UserPersonalInformation.Name = orderInformation.Name;
            order.User.UserPersonalInformation.Surname = orderInformation.Surname;
            order.User.UserPersonalInformation.PhoneNumber = orderInformation.PhoneNumber;
            order.User.Email = orderInformation.Email;

        }

        public void AddBasketLinesToOrder(BasketViewModel basket, Order order)
        {
            foreach (var el in basket.Lines)
            {
                var line = new BasketLine();
                line.OrderId = order.Id;
                line.ProductId = el.Product.Id;
                line.Product.Name = el.Product.Name;
                line.Product.Price = el.Product.Price;
                line.Qty = el.Quantity;
                line.Uom = el.Uom;

                order.BasketLine.Add(line);
            }
        }
    }
}
