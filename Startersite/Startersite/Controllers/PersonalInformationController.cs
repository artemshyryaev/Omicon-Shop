using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Controllers
{
    public class PersonalInformationController : Controller
    {
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

        public ActionResult ManageProducts(int page = 1)
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

        public ActionResult Orders(int page = 1)
        {
            OrdersListModel model = new OrdersListModel
            {
                Orders = ordersRepo.Orders.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    orders => orders.OrderId),
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