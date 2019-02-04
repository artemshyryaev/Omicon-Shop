using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Startersite.Models.Concrete
{
    public class OrderProcessor : Controller, IOrderProcessor
    {
        ShopDBContext context;

        public OrderProcessor()
        {
            context = new ShopDBContext();
        }

        public void ProcessOrder(BasketModel basket, OrderInformation orderInformation)
        {
            //var order = new Orders();
            //try
            //{
            //    UpdateModel(order.orderInformation);
            //    UpdateModel(context.Orders);
            //}
            //catch (Exception e)
            //{

            //}
        }
    }
}