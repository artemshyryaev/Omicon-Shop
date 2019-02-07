using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Models.Concrete
{
    public class OrderProcessor : Controller, IOrderProcessor
    {
        ShopDBContext context;

        public OrderProcessor()
        {
            context = new ShopDBContext();
        }

        public Order ProcessOrder(BasketModel basket, OrderInformation orderInformation)
        {
            Order order = null;

            AddOrderInformationToOrder(ref order, basket, orderInformation);
            AddBasketLinesToOrder(basket, order);
            SaveChanges(order);

            return order;
        }

        void AddOrderInformationToOrder(ref Order order, BasketModel basket, OrderInformation orderInformation)
        {
            order = new Order
            {
                CustomerEmail = orderInformation.Email,
                OrderDate = DateTime.Today,
                OrderTotal = basket.BasketTotal(),

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

        void AddBasketLinesToOrder(BasketModel basket, Order order)
        {
            foreach (var el in basket.Lines)
            {
                var line = new BasketLine();
                line.ProductId = el.Product.ProductId;
                line.ProductName = el.Product.ProductName;
                line.Price = el.Product.Price;
                line.Qty = el.Quantity;
                line.OrderId = order.OrderId;

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