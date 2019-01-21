using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class HomeController : Controller
    {
        private DentDbContext context = new DentDbContext();

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

        [Authorize]
        public ActionResult Cabinet()
        {
            return View();
        }

        [Authorize]
        public ActionResult ProductsList()
        {
            var products = context.Products.ToList();

            return View(products);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ProductsList(Products products)
        {
            //var products = context.Products.ToList();

            return View();
        }
    }
}