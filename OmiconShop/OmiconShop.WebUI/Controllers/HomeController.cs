using OmiconShop.Application.Home;
using OmiconShop.Application.Home.ViewModels;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ProductsList(string type, string productName, int page = 1)
        {
            var model = homeApi.GetProductsListViewModel(type, productName, page, PageSize);

            ViewData["Page"] = page;
            ViewData["Type"] = type;

            return View(model);
        }

        [HttpGet]
        public ActionResult ProductDetails(int? id, string type, int page = 1)
        {
            if (id == null)
                return View("PageNotFound");

            var model = homeApi.GetProductById((int)id);

            if (model == null)
                return View("PageNotFound");

            ViewData["Page"] = page;
            ViewData["Type"] = type;

            return View(model);
        }

        [HttpPost]
        public ActionResult Comment(string comment)
        {

            return View(new CommentViewModel());
        }
    }
}