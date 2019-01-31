using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using Startersite.Models.ModelViews.CheckoutModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Startersite.Models.Concrete;

namespace Startersite.Controllers
{
    public class CheckoutController : Controller
    {
        IOrderProcessor orderProcessor;
        DeliveryMethod shippingMethod;
        PaymentMethod paymentMethod;
        ShippingInformation shippingInformation;
        BasketModel basket;

        public CheckoutController(IOrderProcessor orderProcessor)
        {
            this.orderProcessor = orderProcessor;
        }

        public ActionResult ShippingInformationStep(BasketModel basket)
        {
            this.basket = basket;

            return View(new ShippingInformation());
        }

        public ActionResult DeliveryMethodStep(ShippingInformation shippingInformation)
        {
            this.shippingInformation = shippingInformation;

            return View();
        }

        public ActionResult PaymentMethodStep(DeliveryMethod deliveryMethod)
        {
            shippingMethod = deliveryMethod;

            return View();
        }

        public ActionResult OrderOverview(PaymentMethod paymentMethod)
        {
            this.paymentMethod = paymentMethod;

            if (basket.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Yor basket is empty");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(basket, shippingInformation, shippingMethod, paymentMethod);
            }
            else
            {
                return View();//какое-то вью
            }

            return View();
        }
    }
}