using System.Linq;
using System.Data.Entity;

namespace Startersite.Managers
{
    public class SqlQueries
    {
        public static Order GetOrderById(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.OrderId == orderId);

                return order;
            }
        }

        public static Order GetOrderByIdAndCustomerEmail(int orderId, string email)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.OrderId == orderId 
                    && x.CustomerEmail == email);

                return order;
            }
        }

        public static void DeclineOrderByAdmin(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.First(x => x.OrderId == orderId);
                order.Status = OrderStatuses.Declined;
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void ApproveOrderByAdmin(int orderId)
        {
            using (ShopDBContext context = new ShopDBContext())
            {
                Order order = context.Orders.First(x => x.OrderId == orderId);
                order.Status = OrderStatuses.Approved;
                context.Entry(order).State = EntityState.Modified;
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