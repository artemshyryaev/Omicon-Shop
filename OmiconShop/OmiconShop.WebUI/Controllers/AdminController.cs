﻿using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System;
using OmiconShop.Domain.Enumerations;
using WebMatrix.WebData;
using System.Web.Security;
using OmiconShop.Application.Admin;
using OmiconShop.Application.Admin.ViewModel;

namespace OmiconShop.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        AdminApi adminApi;
        const int PageSize = 10;

        public AdminController(AdminApi adminApi)
        {
            this.adminApi = adminApi;
        }

        [HttpGet]
        public ActionResult PersonalInfo()
        {
            var userName = User.Identity.Name;
            var userModel = adminApi.GetCurrentUserData(userName);

            return View(userModel);
        }

        [HttpPost]
        public ActionResult PersonalInfo(int userId, string email)
        {
            var userEmail = User.Identity.Name;
            var changedUser = adminApi.ChangeUserData(userId, email);

            WebSecurity.Logout();
            FormsAuthentication.SetAuthCookie(changedUser.Email, false);

            TempData["message"] = string.Format("The user email was successfully changed!");

            return View(changedUser);
        }

        [HttpGet]
        public ActionResult ProductList(string productName, int page = 1)
        {
            var productListViewModel = adminApi.GetProductsListViewModel(productName, page, PageSize);

            return View(productListViewModel);
        }

        [HttpGet]
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
                    image.SaveAs(adminApi.CreateProductFullPath(ref product));

                var productModel = adminApi.CreateProduct(product);
                TempData["message"] = string.Format($"{productModel.Name} was successfully added!");

                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            var productViewModel = adminApi.CreateProductViewModelByProductId(productId);
            ViewData["Id"] = productId;

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel product, int productId, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                    image.SaveAs(adminApi.CreateProductFullPath(ref product));

                var productModel = adminApi.EditProduct(productId, product);
                TempData["message"] = string.Format($"Data in {productModel.ProductId}/{productModel.Name} was successfully changed!");

                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                adminApi.DeleteProduct(productId);
                TempData["message"] = string.Format($"{productId} was successfully deleted!");
            }
            else
            {
                TempData["message"] = string.Format($"Something went wrong, please try again later");
            }

            return RedirectToAction("ProductList", "Admin");
        }

        [HttpGet]
        public ActionResult OrderList(string orderId, OrderStatuses? selectedStatus = null, int page = 1)
        {
            var userEmail = User.Identity.Name;
            var model = adminApi.GetOrdersViewModel(orderId, selectedStatus, userEmail, page, PageSize);

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult OrderDetails(int orderId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var retunrUrl = Request.Url.PathAndQuery;
                return RedirectToRoute(new { controller = "Account", action = "Login", returnUrl = retunrUrl });
            }

            var userEmail = User.Identity.GetUserName();
            var order = adminApi.GetCurrentUserOrder(orderId, userEmail);

            if (order == null)
            {
                View("PageNotFound");
            }

            return View(order);
        }

        [HttpGet]
        public ActionResult Approve(int orderId)
        {
            var order = adminApi.ApproveOrder(orderId);

            return View("OrderDetails", order);
        }

        [HttpGet]
        public ActionResult Decline(int orderId)
        {
            var order = adminApi.DeclineOrder(orderId);

            return View("OrderDetails", order);
        }
    }
}