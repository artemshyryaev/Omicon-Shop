using OmiconShop.Application.Repository;
using OmiconShop.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OmiconShop.Application.IRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextHelper helper;

        public ProductRepository(ContextHelper helper)
        {
            this.helper = helper;
        }

        public IList<Product> GetAllProducts()
        {
            using (var context = helper.Create())
                return context.Products.ToList();
        }

        public async Task AddProductAsync(Product product)
        {
            using (var context = helper.Create())
            {
                context.Entry(product).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public Product GetProductById(int orderId)
        {
            using (var context = helper.Create())
                return context.Products
                    .FirstOrDefault(x => x.ProductId == orderId);
        }

        public async Task DeleteProductAsync(int productId)
        {
            using (var context = helper.Create())
            {
                Product product = context.Products
                    .FirstOrDefault(x => x.ProductId == productId);

                context.Entry(product).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task EditProductAsync(Product product)
        {
            using (var context = helper.Create())
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(x => x.ProductId == product.ProductId);

                dbEntry.Name = product.Name;
                dbEntry.Price = product.Price;
                dbEntry.Description = product.Description;
                dbEntry.Type = product.Type;
                dbEntry.ImageUrl = product.ImageUrl;

                context.Entry(dbEntry).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}