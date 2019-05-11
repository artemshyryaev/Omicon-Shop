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

        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            var basket = basketApi.GetCurrentBasket();

            return View(new BasketIndexViewModel { Basket = basket, RetunrUrl = returnUrl });
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(int productId, string returnUrl, double quantity, UOM uom)
        {
            var basket = basketApi.GetCurrentBasket();
            basketApi.AddToCart(basket, productId, quantity, uom);

            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public ActionResult RemoveFromBasket(string productInfo)
        {
            var basket = basketApi.GetCurrentBasket();
            var productId = Convert.ToInt32(productInfo.Split('-')[0]);
            Enum.TryParse((productInfo.Split('-')[1]), out UOM productUOM);

            basketApi.RemoveFromBasket(basket, productId, productUOM);

            return Json(basket);
        }

        [HttpPost]
        public ActionResult EmptyBasket()
        {
            var basket = basketApi.GetCurrentBasket();
            basketApi.EmptyBasket(basket);

            return Json(basket);
        }

        [HttpPost]
        public ActionResult RecalculateBasket(string productId, string productUOM, string qty)
        {
            var basket = basketApi.GetCurrentBasket();
            basket = basketApi.GetModifiedBasket(basket, productId, productUOM, qty);

            return Json(basket);
        }
    }
}