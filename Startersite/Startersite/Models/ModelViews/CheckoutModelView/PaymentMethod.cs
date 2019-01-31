using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews.CheckoutModelView
{
    public class PaymentMethod
    {
        [Display(Name = "Payment method")]
        public MethodOfPayment Payment { get; set; }
    }

    public enum MethodOfPayment
    {
        Visa,

        Mastercard,

        PayPall,

        Dibs,

        Docdata,

        AfterPay,

        Klarna
    }
}