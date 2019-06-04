using OmiconShop.Application.Admin.Operations;
using OmiconShop.Application.Admin.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace OmiconShop.Application.Admin
{
    public class AdminApi
    {
        IOrderRepository orderRepository;
        IUserRepository userRepository;
        IProductRepository productRepository;
        ProductOperations productOperations;
        OrderOperations orderOperations;
        UserOperations userOperations;

        public AdminApi(IOrderRepository orderRepository,
            IUserRepository userRepository, IProductRepository productRepository,
            ProductOperations productOperations, OrderOperations orderOperations,
            UserOperations userOperations)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.productOperations = productOperations;
            this.orderOperations = orderOperations;
            this.userOperations = userOperations;
        }

        public UserViewModel GetCurrentUserData(string userEmail)
        {
            var currentUser =  userRepository.GetUserByEmail(userEmail);
            return userOperations.CreateUserViewModel(currentUser);
        }

        public async Task<UserViewModel> ChangeUserDataAsync(int userId, string userEmail)
        {
            var modifiedUser = await userRepository.ChangeUserEmailAsync(userId, userEmail);
            await orderRepository.ChangeUserEmailInOrdersAsync(userId, modifiedUser.Email);

            var createdUser = userOperations.CreateUserViewModel(modifiedUser);

            return createdUser;
        }

        public ProductsListViewModel GetProductsListViewModel(string productName, int page, int pageSize)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productOperations.GetProducts(page: page, pageSize: pageSize, productName: productName),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    TotalItems = productRepository.GetAllProducts().Count(),
                    ItemsPerPage = pageSize
                }
            };

            return model;
        }

        public Order GetCurrentUserOrder(int orderId, string userEmail)
        {
            if (userEmail == "admin@gmail.com")
                return orderRepository.GetOrderById(orderId);
            else
                return orderRepository.GetOrderByIdAndCustomerEmail(orderId, userEmail);
        }

        public async Task<Order> DeclineOrderAsync(int orderId)
        {
            await orderRepository.DeclineOrderByAdminAsync(orderId);

            return orderRepository.GetOrderById(orderId);
        }

        public async Task<Order> ApproveOrderAsync(int orderId)
        {
            await orderRepository.ApproveOrderByAdminAsync(orderId);

            return orderRepository.GetOrderById(orderId);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await productRepository.DeleteProductAsync(productId);
        }

        public async Task<Product> CreateProductAsync(ProductViewModel productViewModel)
        {
            var product = productOperations.CreateProductModelFromProductViewModel(productViewModel);
            await productRepository.AddProductAsync(product);

            return product;
        }

        public ProductViewModel CreateProductViewModelByProductId(int productId)
        {
            var product = productRepository.GetProductById(productId);
            if (product == null)
                return null;

            return productOperations.CreateProductViewModelFromProductModel(product);
        }

        public OrdersViewModel GetOrdersViewModel(string orderId, OrderStatuses? orderStatus,
             string userEmail, int page, int pageSize)
        {
            OrdersViewModel model = new OrdersViewModel
            {
                Orders = orderOperations.GetOrders(page, pageSize, orderStatus, userEmail, orderId),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = orderRepository.GetAllOrders().Count()
                },
                SelectedStatus = orderStatus
            };

            return model;
        }

        public string CreateProductFullPath(ref ProductViewModel product)
        {
            var filepath = string.IsNullOrEmpty(product.ImageUrl)
                ? "/content/files/" + Guid.NewGuid() + ".png"
                : product.ImageUrl;

            var fullPath = HostingEnvironment.MapPath(filepath);
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);

            productOperations.AddImagePathToProduct(ref product, filepath);

            return fullPath;
        }

        public async Task<Product> EditProductAsync(int productId, ProductViewModel productViewModel)
        {
            var productModel = productOperations.CreateProductModelFromProductViewModel(productViewModel, productId);
            await productRepository.EditProductAsync(productModel);

            return productModel;
        }
    }
}
