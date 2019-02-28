using Startersite.IManagers;
using Startersite.Models;
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
            order = new Order
            {
                CustomerEmail = orderInformation.Email,
                Date = DateTime.Today,
                Total = basket.BasketTotal(),
                Status = OrderStatuses.Pending,

                OrderInformation = new Information
                {
                    Address = orderInformation.Address,
                    Address2 = orderInformation.Address2,
                    City = orderInformation.City,
                    Country = orderInformation.Country,
                    Delivery = orderInformation.Delivery,
                    Name = orderInformation.Name,
                    Surname = orderInformation.Surname,
                    Payment = orderInformation.Payment,
                    PhoneNumber = orderInformation.PhoneNumber,
                    ZipCode = orderInformation.ZipCode,
                    Email = orderInformation.Email
                }
            };
        }

        void AddBasketLinesToOrder(BasketViewModel basket, Order order)
        {
            foreach (var el in basket.Lines)
            {
                var line = new BasketLine();
                line.OrderId = order.Id;
                line.ProductId = el.Product.Id;
                line.ProductName = el.Product.Name;
                line.Price = el.Product.Price;
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