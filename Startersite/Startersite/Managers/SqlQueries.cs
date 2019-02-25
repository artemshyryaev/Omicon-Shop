using System.Linq;
using System.Data.Entity;
using Startersite.Models;
using System;
using WebMatrix.WebData;
using System.Web.Security;
using System.Web.Mvc;
using System.Web;

namespace Startersite.Managers
{
    public class SqlQueries
    {
        public static Order GetOrderById(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.Id == orderId);

                return order;
            }
        }

        public static Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.Id == orderId
                    && x.CustomerEmail == email);

                return order;
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

        internal static void AddProduct(Product product)
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
                Product product = context.Products.FirstOrDefault(x => x.Id == orderId);

                return product;
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

        public static void EditProduct(Product product)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Product dbEntry = context.Products.FirstOrDefault(x => x.Id == product.Id);

                dbEntry.Name = product.Name;
                dbEntry.Price = product.Price;
                dbEntry.Description = product.Description;
                dbEntry.Type = product.Type;
                dbEntry.ImageData = product.ImageData;
                dbEntry.ImageMimeType = product.ImageMimeType;

                context.Entry(dbEntry).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static Users GetUserByEmail(string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Users dbEntry = context.Users.FirstOrDefault(x => x.Email == email);

                return dbEntry;
            }
        }

        public static Users GetUserById(int id)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Users dbEntry = context.Users.FirstOrDefault(x => x.UserId == id);

                return dbEntry;
            }
        }

        public static void ChangeUserEmail(int id, string email)
        {
            var user = GetUserById(id);

            using (ShopDBContext context = new ShopDBContext())
            {
                user.Email = email;
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();

                WebSecurity.Logout();
                FormsAuthentication.SetAuthCookie(user.Email, false);
            }
        }

        public static void ChangeUserEmailInOrders(string oldEmail, string newEmail)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                var dbEntry = context.Orders.Where(x => x.CustomerEmail == oldEmail).
                    Include(x => x.BasketLine).Include(x => x.OrderInformation).ToList();

                foreach (var el in dbEntry)
                {
                    el.CustomerEmail = newEmail;

                    context.Entry(el).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
    }

    public enum OrderStatuses
    {
        Pending,

        Approved,

        Declined
    }
}