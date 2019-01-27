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

        public ActionResult ProductsList(string type, int page = 1)
        {
            ProductsListModel model = new ProductsListModel
            {
                Products = productsRepo.Products.Where(p => type == null || p.Type == type).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.ProductId),
                PagingInfo = new PagingInfo
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