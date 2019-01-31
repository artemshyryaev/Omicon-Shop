using Startersite.Models.ModelViews;
using Startersite.Models.ModelViews.CheckoutModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(BasketModel basket, ShippingInformation shippingInformation,
            DeliveryMethod deliveryMethod, PaymentMethod paymentMethod);
    }
}