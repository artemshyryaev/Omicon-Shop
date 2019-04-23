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

        public AdminApi(IOrderRepository orderRepository,
            IUserRepository userRepository, IProductRepository productRepository,
            ProductOperations productOperations, OrderOperations orderOperations)
        {
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.productOperations = productOperations;
            this.orderOperations = orderOperations;
        }

        public User GetCurrentUserData(string userEmail)
        {
            return userRepository.GetUserByEmail(userEmail);
        }

        public User ChangeUserData(int userId, string userEmail)
        {
            var changedUser = userRepository.ChangeUserEmail(userId, userEmail);
            orderRepository.ChangeUserEmailInOrders(userId, changedUser.Email);

            return changedUser;
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
            Order order;

            if (userEmail == "admin")
                return order = orderRepository.GetOrderById(orderId);
            else
                return order = orderRepository.GetOrderByIdAndCustomerEmail(orderId, userEmail);

        }

        public Order DeclineOrder(int orderId)
        {
            orderRepository.DeclineOrderByAdmin(orderId);

            return orderRepository.GetOrderById(orderId);
        }

        public Order ApproveOrder(int orderId)
        {
            orderRepository.ApproveOrderByAdmin(orderId);

            return orderRepository.GetOrderById(orderId);
        }

        public void DeleteProduct(int productId)
        {
            productRepository.DeleteProduct(productId);
        }

        public Product CreateProduct(ProductViewModel productViewModel)
        {
            var product = productOperations.CreateProductModelFromProductViewModel(productViewModel);
            productRepository.AddProduct(product);

            return product;
        }

        public ProductViewModel AddImagePathToProduct(ref ProductViewModel product)
        {
            var filepath = "/content/files/" + Guid.NewGuid() + ".png";
            productOperations.AddImagePathToProduct(ref product, filepath);

            return product;
        }

        public ProductViewModel CreateProductViewModelByProductId(int productId)
        {
            var product = productRepository.GetProductById(productId);

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

        public Product EditProduct(int productId, ProductViewModel productViewModel)
        {
            var productModel = productOperations.CreateProductModelFromProductViewModel(productViewModel, productId);
            productRepository.EditProduct(productModel);

            return productModel;
        }
    }
}
