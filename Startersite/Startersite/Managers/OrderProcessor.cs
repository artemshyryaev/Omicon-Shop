using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using OmiconShop.Persistence;
using Startersite.IManagers;
using Startersite.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace Startersite.Managers
{
    public class OrderProcessor : Controller, IOrderProcessor
    {
        ShopDBContext context;

        public OrderProcessor()
        {
            context = new ShopDBContext();
        }

        public Order ProcessOrder(BasketViewModel basket, OrderInformationViewModel orderInformation)
        {
            Order order = null;

            AddOrderInformationToOrder(ref order, basket, orderInformation);
            AddBasketLinesToOrder(basket, order);
            SaveChanges(order);

            return order;
        }

        void AddOrderInformationToOrder(ref Order order, BasketViewModel basket, OrderInformationViewModel orderInformation)
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

        void AddBasketLinesToOrder(BasketViewModel basket, Order order)
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

        void SaveChanges(Order order)
        {
            context.Entry(order).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}