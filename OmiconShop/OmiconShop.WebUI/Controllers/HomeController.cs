using OmiconShop.Application.Home;
using System.Linq;
using System.Web.Mvc;

namespace OmiconShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        const int PageSize = 10;
        HomeApi homeApi;

        public HomeController(HomeApi homeApi)
        {
            this.homeApi = homeApi;
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
            var model = homeApi.GetProductsListViewModel(type, productName, page, PageSize);

            ViewData["Page"] = page;
            ViewData["Type"] = type;

            return View(model);
        }

        public ActionResult ProductDetails(int productId, string type, int page = 1)
        {
            var model = homeApi.GetProductById(productId);

            ViewData["Page"] = page;
            ViewData["Type"] = type;

            return View(model);
        }
    }
}