using Startersite.IManagers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class FacetController : Controller
    {
        IProductRepository productRepo;

        public FacetController(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }    

        [ChildActionOnly]
        public ActionResult Types(string selectedType = null)
        {
            ViewBag.Type = selectedType;
            IEnumerable<string> types = productRepo.Products.Select(p => p.Type).Distinct().OrderBy(x => x);

            return View(types);
        }
    }
}