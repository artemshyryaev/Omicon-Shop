using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class BasketController : Controller
    {
        IProductRepository productRepo;

        public BasketController(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new BasketIndexModel { Basket = GetBaskets(), RetunrUrl = returnUrl });
        }

        public BasketModel GetBaskets()
        {
            var basket = (BasketModel)Session["BasketModel"];
            if (basket == null)
            {
                basket = new BasketModel();
                Session["BasketModel"] = basket;
            }

            return basket;
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                GetBaskets().Add(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl});
        }

        public RedirectToRouteResult RemoveFromBasket(int productId, string returnUrl)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                GetBaskets().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult EmptyBasket( string returnUrl)
        {
            var product = productRepo.Products.Count();

            if (product >= 1)
            {
                GetBaskets().ClearBasket();
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}