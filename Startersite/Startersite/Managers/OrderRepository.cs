using Startersite.IManagers;
using Startersite.Models;
using System.Collections.Generic;

namespace Startersite.Managers
{
    public class OrderRepository : IOrderRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }
    }
}