using System.Linq;
using System.Data.Entity;
using System;
using WebMatrix.WebData;
using System.Web.Security;
using System.Web.Mvc;
using System.Web;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using OmiconShop.Persistence;

namespace Startersite.Managers
{
    public class SqlQueries
    {
        public static Order GetOrderById(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.Id == orderId);
            }
        }

        public static Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.Id == orderId
                    && x.User.Email == email);
            }
        }

        public static void DeclineOrderByAdmin(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.First(x => x.Id == orderId);
                order.Status = OrderStatuses.Declined;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void AddProduct(Product product)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                context.Entry(product).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void ApproveOrderByAdmin(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.First(x => x.Id == orderId);
                order.Status = OrderStatuses.Approved;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static Product GetProductById(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                return context.Products.FirstOrDefault(x => x.Id == orderId);
            }
        }

        internal static void DeleteProduct(int productId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Product product = context.Products.FirstOrDefault(x => x.Id == productId);

                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        internal static void DeleteOrder(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.FirstOrDefault(x => x.Id == orderId);

                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void EditProduct(Product product)
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

        public static void ChangeUserEmailInOrders(string oldEmail, string newEmail)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                var dbEntry = context.Orders.Where(x => x.User.Email == oldEmail).
                    Include(x => x.BasketLine).Include(x => x.OrderInformation).ToList();

                foreach (var el in dbEntry)
                {
                    el.User.Email = newEmail;

                    context.Entry(el).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }
}