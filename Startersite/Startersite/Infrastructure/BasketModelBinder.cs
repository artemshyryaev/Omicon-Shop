using Startersite.Models.ViewModel;
using System.Web.Mvc;

namespace Startersite.Infrastructure
{
    public class BasketModelBinder : IModelBinder
    {
        private const string sessionKey = "Basket";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            BasketViewModel basket = null;

            if (controllerContext.HttpContext.Session != null)
            {
                basket = (BasketViewModel)controllerContext.HttpContext.Session[sessionKey];
            }

            if (basket == null)
            {
                basket = new BasketViewModel();
                controllerContext.HttpContext.Session[sessionKey] = basket;
            }

            return basket;
        }
    }
}