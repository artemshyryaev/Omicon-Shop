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

        public IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus)
        {
            IQueryable<Order> query = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).OrderBy(x => x.Id);

            if (orderStatus != null)
                query = query.Where(x => x.Status == orderStatus);

            query = query.Skip((page - 1) * pagesize).Take(pagesize);

            return query.ToList();
        }
    }
}