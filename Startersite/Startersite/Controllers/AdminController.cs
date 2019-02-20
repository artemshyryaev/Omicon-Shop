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
            ViewBag.Id = productId;

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel product, int productId)
        {
            if (ModelState.IsValid)
            {
                var productModel = ProductManager.CreateProductModelFromProductViewModel(product, productId);
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
            OrdersViewModel model = new OrdersViewModel
            {
                Orders = ordersRepo.GetOrders(page, pageSize, selectedStatus),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage  = page,
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
    }
}