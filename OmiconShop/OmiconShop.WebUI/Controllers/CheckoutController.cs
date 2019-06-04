using System.Linq;
using System.Web.Mvc;
using OmiconShop.Domain.Entities;
using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.Checkout;
using OmiconShop.Application.Checkout.ViewModel;
using System.Threading.Tasks;

namespace OmiconShop.WebUI.Controllers
{
    public class CheckoutController : Controller
    {
        CheckoutApi checkoutApi;

        public CheckoutController(CheckoutApi checkoutApi)
        {
            this.checkoutApi = checkoutApi;
        }

        [HttpGet]
        public ActionResult OrderInformation()
        {
            var basket = checkoutApi.GetCurrentBasket();

            if (basket.Lines.Count() == 0)
            {
                TempData["message"] = string.Format("Your basket is empty");
                return RedirectToAction("Index", "Basket");
            }

            return View(new OrderInformationViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> OrderOverview(OrderInformationViewModel orderInformation)
        {
            Order order;
            var basket = checkoutApi.GetCurrentBasket();

            if (basket.Lines.Count() == 0)
            {
                TempData["message"] = string.Format("Your basket is empty");
                return RedirectToAction("Index", "Basket");
            }

            if (ModelState.IsValid)
            {
                order = await checkoutApi.ProcessOrderAsync(basket, orderInformation);
                ViewBag.OrderId = order.OrderId;
            }
            else
            {
                return View("OrderInformation");
            }

            return View(basket);
        }

        [HttpGet]
        public async Task<ActionResult> DeclineOrder(int? id)
        {
            if (id == null)
                return View("PageNotFound");

            await checkoutApi.DeclineOrderAsync((int)id);

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> SubmitOrder(int? id)
        {
            if (id == null)
                return View("PageNotFound");

            var basket = checkoutApi.GetCurrentBasket();

            if (basket.Lines.Count() == 0)
            {
                TempData["message"] = string.Format("Your basket is empty");
                return RedirectToAction("Index", "Basket");
            }

            var order = await checkoutApi.SubmitOrder(basket, (int)id);

            if (order == null)
                return View("PageNotFound");

            return View("OrderSucessfullyCreated", order);
        }
    }
}