using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite
{
    public class OrderRepository : IOrderRepository
    {
        DentDbContext context = new DentDbContext();

        public IEnumerable<Orders> Orders { get { return context.Orders; } }
    }
}