using OmiconShop.Application.Facet;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OmiconShop.WebUI.Controllers
{
    public class FacetController : Controller
    {
        FacetApi facetApi;

        public FacetController(FacetApi facetApi)
        {
            this.facetApi = facetApi;
        }    

        [ChildActionOnly]
        public ActionResult Types(string selectedType = null)
        {
            ViewBag.Type = selectedType;
            var types = facetApi.GetAllProductFacets().ToList();

            return View(types);
        }
    }
}