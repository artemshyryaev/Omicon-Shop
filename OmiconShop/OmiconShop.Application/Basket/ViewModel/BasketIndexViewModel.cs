using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmiconShop.Application.Basket.ViewModel
{
    public class BasketIndexViewModel
    {
        public BasketViewModel Basket { get; set; }

        public string ReturnUrl { get; set; }
    }
}