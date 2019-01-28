using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Startersite.Managers;

namespace Startersite.Controllers
{
    public class PersonalInformationController : Controller
    {
        ShopDBContext context = new ShopDBContext();
        int pageSize = 10;
        IOrderRepository ordersRepo;
        IProductRepository productsRepo;

        public PersonalInformationController(OrderRepository ordersRepo, ProductRepository productsRepo)
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
                Orders = ordersRepo.Orders.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    orders => orders.OrderId),
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
    }
}