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
            Orders order;
            if (basket.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Yor basket is empty");
            }

            if (ModelState.IsValid)
            {
                order = orderProcessor.ProcessOrder(basket, orderInformation);
            }
            else
            {
                return View();//какое-то вью
            }

            ViewBag.OrderId = order.OrderId;

            return View(basket);
        }

        public ActionResult DeclineOrder(int orderId)
        {
            Orders order = context.Orders.First(x => x.OrderId == orderId);

            if (order != null)
            {
                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}