using Startersite.Managers;
using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startersite.IManagers
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus);
    }
}
