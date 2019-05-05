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

        public IList<Order> GetOrders(int page, int pagesize, OrderStatuses? orderStatus,
            string userEmail, string orderId = null)
        {
            var allOrders = orderRepository.GetAllOrders();

            if (userEmail != "admin@gmail.com")
                allOrders = allOrders.Where(x => x.User.Email == userEmail).OrderBy(x => x.OrderId).ToList();
            else
                allOrders = allOrders.OrderBy(x => x.OrderId).ToList();

            allOrders = allOrders.OrderBy(x => x.OrderId).ToList();
            if (!string.IsNullOrEmpty(orderId))
            {
                int orderID = Convert.ToInt32(orderId);
                allOrders = allOrders.Where(e => e.OrderId == orderID).ToList();
            }

            if (orderStatus != null)
                allOrders = allOrders.Where(x => x.Status == orderStatus).ToList();

            allOrders = allOrders.Skip((page - 1) * pagesize).Take(pagesize).ToList();

            return allOrders.ToList();
        }
    }
}
