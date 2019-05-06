using OmiconShop.Application.Basket.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OmiconShop.Application.Basket.Operations
{
    public class BasketOperations
    {
        private const string sessionKey = "Basket";

        public BasketViewModel GetBasket()
        {
            BasketViewModel basket = null;

            if (HttpContext.Current.Session[sessionKey] != null)
            {
                basket = (BasketViewModel)HttpContext.Current.Session[sessionKey];
            }

            if (basket == null)
            {
                basket = new BasketViewModel();
                HttpContext.Current.Session[sessionKey] = basket;
            }

            return basket;
        }
    }
}
