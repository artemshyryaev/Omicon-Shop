using Startersite.IManagers;
using Startersite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Startersite.Managers
{
    public class OrderRepository : IOrderRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }

        public IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus, string userEmail)
        {
            IQueryable<Order> query = null;

            if (userEmail != "admin")
                query = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).
                    Where(x => x.CustomerEmail == userEmail).OrderBy(x => x.Id);
            else
                query = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).OrderBy(x => x.Id);

            if (orderStatus != null)
                query = query.Where(x => x.Status == orderStatus);

            query = query.Skip((page - 1) * pagesize).Take(pagesize);

            return query.ToList();
        }
    }
}