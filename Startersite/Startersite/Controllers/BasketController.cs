using Startersite.IManagers;
using Startersite.Models.ViewModel;
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

        public ActionResult Index(BasketViewModel basket, string returnUrl)
        {
            return View(new BasketIndexViewModel { Basket = basket, RetunrUrl = returnUrl });
        }

        public RedirectToRouteResult AddToCart(BasketViewModel basket, int productId, string returnUrl)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {
                basket.Add(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl});
        }

        public RedirectToRouteResult RemoveFromBasket(BasketViewModel basket, int productId, string returnUrl)
        {
            var product = productRepo.Products.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {
                basket.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult EmptyBasket(BasketViewModel basket, string returnUrl)
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