using System.Linq;
using System.Web.Mvc;
using OmiconShop.Domain.Entities;
using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.Checkout;
using OmiconShop.Application.Checkout.ViewModel;

namespace OmiconShop.WebUI.Controllers
{
    public class CheckoutController : Controller
    {
        CheckoutApi checkoutApi;

        public CheckoutController(CheckoutApi checkoutApi)
        {
            this.checkoutApi = checkoutApi; 
        }

        public ActionResult OrderInformation()
        {
            return View(new OrderInformationViewModel());
        }

        public ActionResult OrderOverview(BasketViewModel basket, OrderInformationViewModel orderInformation)
        {
            Order order;
            if (basket.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your basket is empty");
            }

            if (ModelState.IsValid)
            {
                order = checkoutApi.ProcessOrder(basket, orderInformation);
                ViewBag.OrderId = order.Id;
            }
            else
            {
                return View("OrderInformation");
            }

            return View(basket);
        }

        public ActionResult DeclineOrder(int orderId)
        {
            checkoutApi.DeclineOrder(orderId);

            return View();
        }

        public ActionResult SubmitOrder(BasketViewModel basket, int orderId)
        {
            var order = checkoutApi.SubmitOrder(basket, orderId);

            return View("OrderSucessfullyCreated", order);
        }
    }
}