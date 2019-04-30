using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OmiconShop.Application.Admin.Operations
{
    public class OrderOperations
    {
        IOrderRepository orderRepository;

        public OrderOperations(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus,
            string userEmail, string orderId = null)
        {
            var allOrders = orderRepository.GetAllOrders();

            if (userEmail != "admin@gmail.com")
                allOrders = allOrders.Where(x => x.User.Email == userEmail).OrderBy(x => x.OrderId);
            else
                allOrders = allOrders.OrderBy(x => x.OrderId);

            allOrders = allOrders.OrderBy(x => x.OrderId);
            if (!string.IsNullOrEmpty(orderId))
            {
                int orderID = Convert.ToInt32(orderId);
                allOrders = allOrders.Where(e => e.OrderId == orderID);
            }

            if (orderStatus != null)
                allOrders = allOrders.Where(x => x.Status == orderStatus);

            allOrders = allOrders.Skip((page - 1) * pagesize).Take(pagesize);

            return allOrders.ToList();
        }
    }
}
