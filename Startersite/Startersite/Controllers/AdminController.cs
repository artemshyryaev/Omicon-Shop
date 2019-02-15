using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Startersite.Managers;
using Microsoft.AspNet.Identity;
using Startersite.IManagers;
using Startersite.Models.ViewModel;
using Startersite.Models;

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

        public ActionResult ProductList(int page = 1)
        {
            var manager = new ProductManager(productsRepo);

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = manager.GetProducts(page, pageSize),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    TotalItems = productsRepo.Products.Count(),
                    ItemsPerPage = pageSize
                }
            };
            return View(model);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                SqlQueries.AddProduct(product);
                TempData["message"] = string.Format($"{product.Id}/{product.Name} was successfully added!");
                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult EditProduct(int productId)
        {
            Product product = SqlQueries.GetProductById(productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                SqlQueries.EditProduct(product);
                TempData["message"] = string.Format($"Data in {product.Id}/{product.Name} was successfully changed!");
                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                SqlQueries.DeleteProduct(productId);
                TempData["message"] = string.Format($"{productId} was successfully deleted!");               
            }
            else
            {
                TempData["message"] = string.Format($"Something went wrong, please try again later");
            }

            return RedirectToAction("ProductList", "Admin");
        }

        public ActionResult OrderDetails(int orderId)
        {
            Order order = null;
            if (!User.Identity.IsAuthenticated)
            {
                var retunrUrl = Request.Url.PathAndQuery;
                return RedirectToRoute(new { controller = "Account", action = "Login", returnUrl = retunrUrl });
            }

            var userEmail = User.Identity.GetUserName();

            if (userEmail == "admin")
            {
                order = SqlQueries.GetOrderById(orderId);
            }
            else
            {
                order = SqlQueries.GetOrderByIdAndCustomerEmail(orderId, userEmail);
            }            

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