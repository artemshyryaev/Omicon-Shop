using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using OmiconShop.Domain.Entities;
using Startersite.Repository;

namespace Startersite.Managers
{
    public class AdminManager
    {
        UserRepository userRepository = new UserRepository();
        Repository.ProductRepository productRepository = new Startersite.Repository.ProductRepository();
        Repository.OrderRepository orderRepository = new Repository.OrderRepository();

        public User GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email); ;
        }

        public void ChangeUserEmail(int id, string email)
        {
            userRepository.ChangeUserEmail(id, email);
        }

        public void ChangeUserEmailInOrders(string oldEmail, string newEmail)
        {
            orderRepository.ChangeUserEmailInOrders(oldEmail, newEmail);
        }

        public void AddProduct(Product product)
        {
            productRepository.AddProduct(product);
        }

        public Product GetProductById(int orderId)
        {
            return productRepository.GetProductById(orderId);
        }

        public void EditProduct(Product product)
        {
            productRepository.EditProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            productRepository.DeleteProduct(productId);
        }

        public Order GetOrderById(int orderId)
        {
            return orderRepository.GetOrderById(orderId);
        }

        public Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            return orderRepository.GetOrderByIdAndCustomerEmail(orderId, email);
        }

        public void ApproveOrderByAdmin(int orderId)
        {
            orderRepository.ApproveOrderByAdmin(orderId);
        }

        public void DeclineOrderByAdmin(int orderId)
        {
            orderRepository.DeclineOrderByAdmin(orderId);
        }
    }
}