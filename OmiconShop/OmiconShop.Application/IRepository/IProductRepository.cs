using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OmiconShop.Application.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int orderId);

        void AddProductAsync(Product product);

        void DeleteProductAsync(int productId);

        void EditProductAsync(Product product);
    }
}