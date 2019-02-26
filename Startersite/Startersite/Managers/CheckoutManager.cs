using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Managers
{
    public class CheckoutManager
    {
        public Order GetOrderById(int orderId)
        {
            return SqlQueries.GetOrderById(orderId);
        }

        public void DeleteOrder(int orderId)
        {
            SqlQueries.DeleteOrder(orderId);
        }
    }
}