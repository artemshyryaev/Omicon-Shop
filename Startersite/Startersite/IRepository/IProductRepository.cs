using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.IRepository
{
    public interface IProductRepository
    {
        Product GetProductById(int orderId);

        void AddProduct(Product product);

        void DeleteProduct(int productId);

        void EditProduct(Product product);
    }
}