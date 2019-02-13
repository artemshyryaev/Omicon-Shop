using Startersite.IManagers;
using Startersite.Models.ModelViews;
using System.Linq;
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

        public ActionResult Index(BasketModel basket, string returnUrl)
        {
            return View(new BasketIndexModel { Basket = basket, RetunrUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(BasketModel basket, int productId, string returnUrl)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {
                basket.Add(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl});
        }

        public RedirectToRouteResult RemoveFromBasket(BasketModel basket, int productId, string returnUrl)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {
                basket.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult EmptyBasket(BasketModel basket, string returnUrl)
        {
            var product = productRepo.Products.Count();

            if (product >= 1)
            {
                basket.ClearBasket();
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}