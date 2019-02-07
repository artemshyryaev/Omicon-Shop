using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Startersite.Models.Concrete;
using System.Data.Entity;
using Startersite.Managers;

namespace Startersite.Controllers
{
    public class CheckoutController : Controller
    {
        ShopDBContext context;
        IOrderProcessor orderProcessor;
        IEmailSender emailSender;

        public CheckoutController(IOrderProcessor orderProcessor, IEmailSender emailSender)
        {
            context = new ShopDBContext();
            this.orderProcessor = orderProcessor;
            this.emailSender = emailSender;
        }

        public ActionResult OrderInformation()
        {
            return View(new OrderInformation());
        }

        public ActionResult OrderOverview(BasketModel basket, OrderInformation orderInformation)
        {
            Order order;
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
                return RedirectToAction("DeclinedOrder", "Checkout");
            }

            ViewBag.OrderId = order.OrderId;

            return View(basket);
        }

        public ActionResult DeclineOrder(int orderId)
        {
            Order order = SqlQueries.GetOrderById(orderId);

            if (order != null)
            {
                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return RedirectToAction("DeclinedOrder", "Checkout");
        }

        public ActionResult SubmitOrder(int orderId)
        {
            Order order = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.OrderId == orderId);

            emailSender.SendOrderConfirmationEmail(order);           

            return View("OrderSucessfullyCreated", order);
        }
    }
}