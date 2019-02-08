using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Startersite.Managers;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Startersite.Controllers
{
    public class AdminController : Controller
    {
        ShopDBContext context = new ShopDBContext();
        int pageSize = 10;
        IOrderRepository ordersRepo;
        IProductRepository productsRepo;

        public AdminController(IOrderRepository ordersRepo, IProductRepository productsRepo)
        {
            this.ordersRepo = ordersRepo;
            this.productsRepo = productsRepo;
        }

        public ActionResult PersonalInfo()
        {
            return View();
        }

        public ActionResult ManageProducts(string type, int page = 1)
        {
            ProductManager manager = new ProductManager(productsRepo);

            ProductsListModel model = new ProductsListModel
            {
                Products = manager.GetProducts(type, page, pageSize),
                PagingInfo = new PagingInfoModel
                {
                    CurrentPage = page,
                    TotalItems = type == null ? productsRepo.Products.Count() : productsRepo.Products.Where(p => p.Type == type).Count(),
                    ItemsPerPage = pageSize
                },
                Type = type
            };

            return View(model);
        }

        public ActionResult Orders(int page = 1)
        {
            OrdersListModel model = new OrdersListModel
            {
                //Orders = ordersRepo.Orders.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                //    orders => orders.),
                PagingInfo = new PagingInfoModel
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = ordersRepo.Orders.Count()
                }
            };

            return View(model);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Products products)
        {
            context.Entry(products).State = EntityState.Added;
            context.SaveChanges();

            return View();
        }

        public ActionResult OrderDetails(int orderId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var retunrUrl = Request.Url.PathAndQuery;
                return RedirectToRoute(new { controller = "Account", action = "Login", returnUrl = retunrUrl });
            }


            var userId = Convert.ToInt32(User.Identity.GetUserId());
            var userEmail = context.Users.FirstOrDefault(x => x.UserId == userId).Email;

            Order order = context.Orders.First(x => x.OrderId == orderId && x.CustomerEmail == userEmail);

            if (order == null)
            {
                View("PageNotFound");
            }

            return View(order);
        }

        public ActionResult Approve(Order order, int orderId)
        {
            SqlQueries.ApproveOrderByAdmin(orderId);

            return View("OrderDetails", order);
        }

        public ActionResult Decline(Order order, int orderId)
        {
            SqlQueries.DeclineOrderByAdmin(orderId);

            return View("OrderDetails", order);
        }
    }
}