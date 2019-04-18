using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using OmiconShop.Domain.Entities;

namespace Startersite.Managers
{
    public class AdminManager
    {
        public User GetUserByEmail(string email)
        {
            return SqlQueries.GetUserByEmail(email); ;
        }

        public void ChangeUserEmail(int id, string email)
        {
            SqlQueries.ChangeUserEmail(id, email);
        }

        public void ChangeUserEmailInOrders(string oldEmail, string newEmail)
        {
            SqlQueries.ChangeUserEmailInOrders(oldEmail, newEmail);
        }

        public void AddProduct(Product product)
        {
            SqlQueries.AddProduct(product);
        }

        public Product GetProductById(int orderId)
        {
            return SqlQueries.GetProductById(orderId);
        }

        public void EditProduct(Product product)
        {
            SqlQueries.EditProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            SqlQueries.DeleteProduct(productId);
        }

        public Order GetOrderById(int orderId)
        {
            return SqlQueries.GetOrderById(orderId);
        }

        public Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            return SqlQueries.GetOrderByIdAndCustomerEmail(orderId, email);
        }

        public void ApproveOrderByAdmin(int orderId)
        {
            SqlQueries.ApproveOrderByAdmin(orderId);
        }

        public void DeclineOrderByAdmin(int orderId)
        {
            SqlQueries.DeclineOrderByAdmin(orderId);
        }
    }
}