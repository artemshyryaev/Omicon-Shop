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

        public Orders ProcessOrder(BasketModel basket, OrderInformation orderInformation)
        {
            Orders order = null;

            AddOrderInformationToOrder(ref order, basket, orderInformation);
            AddBasketLinesToOrder(basket, order);
            SaveChanges(order);

            return order;
        }

        void AddOrderInformationToOrder(ref Orders order, BasketModel basket, OrderInformation orderInformation)
        {
            order = new Orders
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
                    ZipCode = orderInformation.ZipCode
                }
            };
        }

        void AddBasketLinesToOrder(BasketModel basket, Orders order)
        {
            foreach (var el in basket.Lines)
            {
                var line = new BasketLine();
                line.ProductId = el.Product.ProductId;
                line.Qty = el.Quantity;

                order.BasketLine.Add(line);
            }
        }

        void SaveChanges(Orders order)
        {
            context.Entry(order).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}