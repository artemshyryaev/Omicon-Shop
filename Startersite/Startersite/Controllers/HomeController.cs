using System.Linq;
using System.Web.Mvc;
using Startersite.Filters;
using Startersite.Managers;
using Startersite.IManagers;
using Startersite.Models.ViewModel;

namespace Startersite.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        private IProductRepository productsRepo;
        int pageSize = 10;

        public HomeController(IProductRepository productsRepo)
        {
            this.productsRepo = productsRepo;
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

        public ActionResult ProductsList(string type, int page = 1)
        {
            var manager = new ProductManager(productsRepo);

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = manager.GetProducts(page, pageSize, type),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    TotalItems = type == null ? productsRepo.Products.Count()
                        : productsRepo.Products.Where(p => p.Type == type).Count(),
                    ItemsPerPage = pageSize
                },
                Type = type
            };

            return View(model);
        }
    }
}