using Startersite.IManagers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using OmiconShop.Domain.Enumerations;

namespace Startersite.Managers
{
    public class OrderRepository : IOrderRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }

        public IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus, string userEmail, string orderId = null)
        {
            IQueryable<Order> query = context.Orders
                    .Include(e => e.OrderInformation)
                    .Include(e => e.BasketLine);

            if (userEmail != "admin")
                query = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).
                    Where(x => x.User.Email == userEmail).OrderBy(x => x.Id);
            else
                query = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).OrderBy(x => x.Id);

            query = query.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(orderId))
            {
                int orderID = Convert.ToInt32(orderId);
                query = query.Where(e => e.Id == orderID);
            }

            if (orderStatus != null)
                query = query.Where(x => x.Status == orderStatus);

            query = query.Skip((page - 1) * pagesize).Take(pagesize);

            return query.ToList();
        }
    }
}