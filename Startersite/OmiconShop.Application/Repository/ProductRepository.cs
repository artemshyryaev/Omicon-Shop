using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using Startersite.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Startersite.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                context.Entry(product).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Product GetProductById(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Products.FirstOrDefault(x => x.Id == orderId);
            }
        }

        public void DeleteProduct(int productId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Product product = context.Products.FirstOrDefault(x => x.Id == productId);

                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Product dbEntry = context.Products.FirstOrDefault(x => x.Id == product.Id);

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