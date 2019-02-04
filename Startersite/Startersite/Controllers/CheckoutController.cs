using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Startersite.Models.Concrete;
using System.Data.Entity;

namespace Startersite.Controllers
{
    public class CheckoutController : Controller
    {
        ShopDBContext context;
        IOrderProcessor orderProcessor;

        public CheckoutController(IOrderProcessor orderProcessor)
        {
            context = new ShopDBContext();
            this.orderProcessor = orderProcessor;
        }

        public ActionResult OrderInformation()
        {
            return View(new OrderInformation());
        }

        public ActionResult OrderOverview(BasketModel basket, OrderInformation orderInformation)
        {
            Orders order = new Orders
            {
                CustomerEmail = orderInformation.Email,
                OrderDate = DateTime.Today,
                OrderTotal = basket.BasketTotal(),

                OrderInformation = new Information {
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

            foreach (var el in basket.Lines)
            {
                var line = new BasketLine();
                line.ProductId = el.Product.ProductId;
                line.Qty = el.Quantity;

                order.BasketLine.Add(line);
            }

            context.Entry(order).State = EntityState.Added;
            context.SaveChanges();

            if (basket.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Yor basket is empty");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(basket, orderInformation);
            }
            else
            {
                return View();//какое-то вью
            }

            return View();
        }
    }
}