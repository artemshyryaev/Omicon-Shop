using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite
{
    public class OrderRepository : IOrderRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Order> Orders { get { return context.Orders; } }
    }
}