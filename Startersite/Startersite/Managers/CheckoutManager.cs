using OmiconShop.Domain.Entities;
using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Managers
{
    public class CheckoutManager
    {
        Repository.OrderRepository orderRepository = new Repository.OrderRepository();

        public Order GetOrderById(int orderId)
        {
            return orderRepository.GetOrderById(orderId);
        }

        public void DeleteOrder(int orderId)
        {
            orderRepository.DeleteOrder(orderId);
        }
    }
}