using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews.CheckoutModelView
{
    public class DeliveryMethod
    {
        [Display(Name ="Delivery method")]
        public MethodsOfDelivery Delivery { get; set; }
    }

    public enum MethodsOfDelivery
    {
        Fedex,

        NovaPoshta,

        Buckaroo,

        Post24,

        UaDelivery
    }
}