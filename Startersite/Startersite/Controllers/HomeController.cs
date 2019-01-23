using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productsRepo;
        private IOrderRepository ordersRepo;
        int pageSize = 10;

        public HomeController(IProductRepository productsRepo, IOrderRepository ordersRepo)
        {
            this.productsRepo = productsRepo;
            this.ordersRepo = ordersRepo;
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

        [Authorize]
        public ActionResult Cabinet()
        {
            return View();
        }

        [Authorize]
        public ActionResult ProductsList(int page = 1)
        {
            ProductsListModel model = new ProductsListModel
            {
                Products = productsRepo.Products.OrderBy(
                    products => products.ProductId).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = productsRepo.Products.Count(),
                    ItemsPerPage = pageSize
                }
            };

            return View(model);
        }

        public ActionResult OrdersList(int page = 1)
        {
            OrdersListModel model = new OrdersListModel
            {
                Orders = ordersRepo.Orders.OrderBy(
                    orders => orders.OrderId).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = ordersRepo.Orders.Count()
                }
            };

            return View(model);
        }
    }
}