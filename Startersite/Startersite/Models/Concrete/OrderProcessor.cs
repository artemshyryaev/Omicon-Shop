using Startersite.Models.Abstract;
using Startersite.Models.ModelViews;
using Startersite.Models.ModelViews.CheckoutModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.Concrete
{
    public class OrderProcessor : IOrderProcessor
    {
        ShopDBContext context;

        public OrderProcessor()
        {
            context = new ShopDBContext();
        }

        public void ProcessOrder(BasketModel basket, ShippingInformation shippingInformation,
            DeliveryMethod deliveryMethod, PaymentMethod paymentMethod)
        {
            //context.Orders.Add()
        }
    }
}