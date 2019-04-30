using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.IRepository
{
    public class ProductRepository : IProductRepository
    {
        ShopDBContext context;

        public ProductRepository(ShopDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAllProducts() => context.Products;

        public void AddProduct(Product product)
        {
            using (context)
            {
                context.Entry(product).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Product GetProductById(int orderId)
        {
            using (context)
            {
                return context.Products.FirstOrDefault(x => x.ProductId == orderId);
            }
        }

        public void DeleteProduct(int productId)
        {
            using (context)
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductId == productId);

                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            using (context)
            {
                Product dbEntry = context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

                dbEntry.Name = product.Name;
                dbEntry.Price = product.Price;
                dbEntry.Description = product.Description;
                dbEntry.Type = product.Type;
                dbEntry.ImageUrl = product.ImageUrl;

                context.Entry(dbEntry).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}