using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Startersite.Managers;
using Microsoft.AspNet.Identity;
using Startersite.IManagers;
using Startersite.Models.ViewModel;
using Startersite.Models;
using System.Web;
using System.IO;
using System;

namespace Startersite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        int pageSize = 10;
        IOrderRepository ordersRepo;
        IProductRepository productsRepo;
        AdminManager adminManager;

        public AdminController(IOrderRepository ordersRepo, IProductRepository productsRepo)
        {
            this.ordersRepo = ordersRepo;
            this.productsRepo = productsRepo;
            this.adminManager = new AdminManager();
        }

        public ActionResult PersonalInfo()
        {
            var userName = User.Identity.Name;
            var userModel = adminManager.GetUserByEmail(userName);

            return View(userModel);
        }

        [HttpPost]
        public ActionResult PersonalInfo(int userId, string email)
        {
            var userEmail = User.Identity.Name;

            adminManager.ChangeUserEmail(userId, email);
            adminManager.ChangeUserEmailInOrders(userEmail, email);

            var userModel = adminManager.GetUserByEmail(email);

            TempData["message"] = string.Format("The user email was successfully changed!");

            return View(userModel);
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
        public ActionResult AddProduct(ProductViewModel product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filepath = "/content/files/" + Guid.NewGuid() + ".png";

                    product = ProductManager.AddImagePathToProduct(product, filepath);
                }

                var productModel = ProductManager.CreateProductModelFromProductViewModel(product);
                adminManager.AddProduct(productModel);
                TempData["message"] = string.Format($"{productModel.Name} was successfully added!");

                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult EditProduct(int productId)
        {
            var product = adminManager.GetProductById(productId);
            var productViewModel = ProductManager.CreateProductViewModelFromProductModel(product);
            ViewData["Id"] = productId;

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel product, int productId, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filepath = string.IsNullOrEmpty(product.ImageUrl) ? "/content/files/" + Guid.NewGuid() + ".png" : product.ImageUrl;
                    var fullPath = Server.MapPath(filepath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    image.SaveAs(fullPath);

                    product = ProductManager.AddImagePathToProduct(product, filepath);
                }

                var productModel = ProductManager.CreateProductModelFromProductViewModel(product, productId);
                adminManager.EditProduct(productModel);
                TempData["message"] = string.Format($"Data in {productModel.Id}/{productModel.Name} was successfully changed!");

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
                adminManager.DeleteProduct(productId);
                TempData["message"] = string.Format($"{productId} was successfully deleted!");
            }
            else
            {
                TempData["message"] = string.Format($"Something went wrong, please try again later");
            }

            return RedirectToAction("ProductList", "Admin");
        }

        public ActionResult OrderList(OrderStatuses? selectedStatus = null, int page = 1)
        {
            var email = User.Identity.Name;

            OrdersViewModel model = new OrdersViewModel
            {
                Orders = ordersRepo.GetOrders(page, pageSize, selectedStatus, email),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = ordersRepo.Orders.Count()
                },
                SelectedStatus = selectedStatus
            };

            return View(model);
        }

        [AllowAnonymous]
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
                order = adminManager.GetOrderById(orderId);
            }
            else
            {
                order = adminManager.GetOrderByIdAndCustomerEmail(orderId, userEmail);
            }

            if (order == null)
            {
                View("PageNotFound");
            }

            return View(order);
        }

        public ActionResult Approve(int orderId)
        {
            adminManager.ApproveOrderByAdmin(orderId);
            var order = adminManager.GetOrderById(orderId);

            return View("OrderDetails", order);
        }

        public ActionResult Decline(int orderId)
        {
            adminManager.DeclineOrderByAdmin(orderId);
            var order = adminManager.GetOrderById(orderId);

            return View("OrderDetails", order);
        }
    }
}