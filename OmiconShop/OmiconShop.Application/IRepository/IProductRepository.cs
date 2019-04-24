using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int orderId);

        void AddProduct(Product product);

        void DeleteProduct(int productId);

        void EditProduct(Product product);
    }
}