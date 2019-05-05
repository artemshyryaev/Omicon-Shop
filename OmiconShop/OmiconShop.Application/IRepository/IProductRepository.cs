using OmiconShop.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public interface IProductRepository
    {
        IList<Product> GetAllProducts();

        Product GetProductById(int orderId);

        Task AddProductAsync(Product product);

        Task DeleteProductAsync(int productId);

        Task EditProductAsync(Product product);
    }
}