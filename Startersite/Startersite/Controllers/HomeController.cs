using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Startersite.Filters;

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

        public ActionResult ProductsList(int page = 1)
        {
            ProductsListModel model = new ProductsListModel
            {
                Products = productsRepo.Products.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.ProductId),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = productsRepo.Products.Count(),
                    ItemsPerPage = pageSize
                }
            };

            return View(model);
        }
    }
}