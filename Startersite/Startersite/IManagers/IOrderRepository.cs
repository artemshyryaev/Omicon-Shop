using System;
using OmiconShop.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmiconShop.Domain.Enumerations;

namespace Startersite.IManagers
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus, string userEmail, string orderId);
    }
}
