using System.Linq;
using System.Data.Entity;
using Startersite.Models;

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

        public static void EditProduct(Product product)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Product dbEntry = context.Products.FirstOrDefault(x => x.Id == product.Id);

                dbEntry.Name = product.Name;
                dbEntry.Price = product.Price;
                dbEntry.Description = product.Description;
                dbEntry.Type = product.Type;

                context.Entry(dbEntry).State = EntityState.Modified;
                context.SaveChanges();
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