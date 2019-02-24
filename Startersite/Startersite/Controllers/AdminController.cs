using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Startersite.Managers;
using Microsoft.AspNet.Identity;
using Startersite.IManagers;
using Startersite.Models.ViewModel;
using Startersite.Models;
using System.Web;

namespace Startersite.Controllers
{
    [Authorize]
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
            var userName = User.Identity.Name;
            var userModel = SqlQueries.GetUserByEmail(userName);

            return View(userModel);
        }

        [HttpPost]
        public ActionResult PersonalInfo(int userId, string email)
        {
            var userEmail = User.Identity.Name;

            SqlQueries.ChangeUserEmail(userId, email);
            SqlQueries.ChangeUserEmailInOrders(userEmail, email);
            var userModel = SqlQueries.GetUserByEmail(email);

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
        public ActionResult AddProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productModel = ProductManager.CreateProductModelFromProductViewModel(product);
                SqlQueries.AddProduct(productModel);
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
            Product product = SqlQueries.GetProductById(productId);
            var productViewModel = ProductManager.CreateProductViewModelFromProductModel(product);
            ViewData["Id"] = productId;

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel product, int productId, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                var updatedProduct = ProductManager.AddImageDataToProduct(image);
                //image.InputStream.Read(updatedProduct.ImageData, 0, image.ContentLength);
                var productModel = ProductManager.CreateProductModelFromProductViewModel(updatedProduct, productId);
                SqlQueries.EditProduct(productModel);
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
                SqlQueries.DeleteProduct(productId);
                TempData["message"] = string.Format($"{productId} was successfully deleted!");
            }
            else
            {
                TempData["message"] = string.Format($"Something went wrong, please try again later");
            }

            return RedirectToAction("ProductList", "Admin");
        }

        public ActionResult OrderList(OrderStatuses? selectedStatus, int page = 1)
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

        public ActionResult Approve(int orderId)
        {
            SqlQueries.ApproveOrderByAdmin(orderId);
            var order = SqlQueries.GetOrderById(orderId);

            return View("OrderDetails", order);
        }

        public ActionResult Decline(int orderId)
        {
            SqlQueries.DeclineOrderByAdmin(orderId);
            var order = SqlQueries.GetOrderById(orderId);

            return View("OrderDetails", order);
        }

        public FileContentResult GetImage(int productId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                var productModel = context.Products.FirstOrDefault(x => x.Id == productId);

                if (productModel.ImageData != null && productModel.ImageMimeType != null)
                    return File(productModel.ImageData, productModel.ImageMimeType);
                else
                    return null;
            }
        }
    }
}