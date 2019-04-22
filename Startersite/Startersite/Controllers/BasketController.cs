using OmiconShop.Application.Basket;
using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Domain.Enumerations;
using System.Linq;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class BasketController : Controller
    {
        BasketApi basketApi;

        public BasketController(BasketApi basketApi)
        {
            this.basketApi = basketApi;
        }

        public ActionResult Index(BasketViewModel basket, string returnUrl)
        {
            return View(new BasketIndexViewModel { Basket = basket, RetunrUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(BasketViewModel basket, int productId, string returnUrl, double quantity, UOM uom)
        {
            basketApi.AddToCart(basket, productId, quantity, uom);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromBasket(BasketViewModel basket, int productId, string returnUrl, UOM uom)
        {
            basketApi.RemoveFromBasket(basket, productId, uom);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult EmptyBasket(BasketViewModel basket, string returnUrl)
        {
            basketApi.EmptyBasket(basket);

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}