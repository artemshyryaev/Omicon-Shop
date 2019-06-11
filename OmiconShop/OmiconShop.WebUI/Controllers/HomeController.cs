using OmiconShop.Application.Home;
using OmiconShop.Application.Home.ViewModels;
using System.Threading.Tasks;
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
            ViewData["productProbability"] = homeApi.GetProductAverageProbability((int)id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Comments(string comments, int? id, string probability)
        {
            if (id == null)
                return View("PageNotFound");

            if (string.IsNullOrEmpty(comments))
            {
                ViewData["productProbability"] = probability;
                return PartialView("_Comments", new CommentsViewModel());
            }

            ViewData["productProbability"] = await homeApi.GetProductAverageProbability((int)id, comments);

            return PartialView("_Comments", new CommentsViewModel());
        }
    }
}