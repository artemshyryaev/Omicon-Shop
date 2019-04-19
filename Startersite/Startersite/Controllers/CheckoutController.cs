using System.Linq;
using System.Web.Mvc;
using Startersite.Managers;
using Startersite.IManagers;
using Startersite.Models.ViewModel;
using OmiconShop.Domain.Entities;

namespace Startersite.Controllers
{
    public class CheckoutController : Controller
    {
        IOrderProcessor orderProcessor;
        IEmailSender emailSender;
        CheckoutManager checkoutManager;

        public CheckoutController(IOrderProcessor orderProcessor, IEmailSender emailSender)
        {
            this.orderProcessor = orderProcessor;
            this.emailSender = emailSender;
            checkoutManager = new CheckoutManager();
            
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
                order = orderProcessor.ProcessOrder(basket, orderInformation);
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
            checkoutManager.DeleteOrder(orderId);

            return View();
        }

        public ActionResult SubmitOrder(BasketViewModel basket, int orderId)
        {
            if (basket != null)
            {
                basket.ClearBasket();
            }

            var order = checkoutManager.GetOrderById(orderId);
            emailSender.SendOrderConfirmationEmail(order);

            return View("OrderSucessfullyCreated", order);
        }
    }
}