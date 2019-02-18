using Startersite.IManagers;
using Startersite.Models;
using System.Collections.Generic;

namespace Startersite.Managers
{
    public class OrderRepository : IOrderRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }

        public IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatuses.All:
                    return Orders.Skip((page - 1) * pagesize).Take(pagesize).OrderBy(x => x.Id);
                case OrderStatuses.Pending:
                    return orderRepository.Orders.Where(x => x.Status == OrderStatuses.Pending).
                        Skip((page - 1) * pagesize).Take(pagesize).OrderBy(x => x.Id);
                case OrderStatuses.Approved:
                    return orderRepository.Orders.Where(x => x.Status == OrderStatuses.Approved).
                        Skip((page - 1) * pagesize).Take(pagesize).OrderBy(x => x.Id);
                case OrderStatuses.Declined:
                    return orderRepository.Orders.Where(x => x.Status == OrderStatuses.Declined).
                        Skip((page - 1) * pagesize).Take(pagesize).OrderBy(x => x.Id);
            }

            return orderRepository.Orders.Skip((page - 1) * pagesize).Take(pagesize).OrderBy(x => x.Id);
        }
    }
}