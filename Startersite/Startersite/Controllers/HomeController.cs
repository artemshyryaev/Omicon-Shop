using System.Linq;
using System.Web.Mvc;
using Startersite.Filters;
using Startersite.Managers;
using Startersite.IManagers;
using Startersite.Models.ViewModel;

namespace Startersite.Controllers
{
    public class HomeController : Controller
    {
        const int PageSize = 10;
        private IProductRepository productsRepo;
        HomeManager homeManager;

        public HomeController(IProductRepository productsRepo)
        {
            this.productsRepo = productsRepo;
            homeManager = new HomeManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductsList(string type, string productName, int page = 1)
        {
            var manager = new ProductManager(productsRepo);

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = manager.GetProducts(page, PageSize, type, productName),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    TotalItems = type == null ? productsRepo.Products.Count()
                        : productsRepo.Products.Where(p => p.Type == type).Count(),
                    ItemsPerPage = PageSize
                },
                Type = type
            };

            ViewData["Page"] = page;
            ViewData["Type"] = type;

            return View(model);
        }

        public ActionResult ProductDetails(int productId, string type, int page = 1)
        {
            var model = homeManager.GetProductById(productId);

            ViewData["Page"] = page;
            ViewData["Type"] = type;

            return View(model);
        }
    }
}