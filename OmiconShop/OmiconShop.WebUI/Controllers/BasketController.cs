using OmiconShop.Application.Basket;
using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OmiconShop.WebUI.Controllers
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

        [HttpPost]
        public ActionResult RemoveFromBasket(BasketViewModel basket, string productInfo)
        {
            var productId = Convert.ToInt32(productInfo.Split('-')[0]);
            Enum.TryParse((productInfo.Split('-')[1]), out UOM productUOM);

            basketApi.RemoveFromBasket(basket, productId, productUOM);

            return Json(basket);
        }

        [HttpPost]
        public ActionResult EmptyBasket(BasketViewModel basket)
        {
            basketApi.EmptyBasket(basket);

            return Json(basket);
        }
    }
}