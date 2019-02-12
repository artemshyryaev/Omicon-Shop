using Startersite.Models.ModelViews;
using System.Web.Mvc;

namespace Startersite.Infrastructure
{
    public class BasketModelBinder : IModelBinder
    {
        private const string sessionKey = "Basket";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            BasketModel basket = null;

            if (controllerContext.HttpContext.Session != null)
            {
                basket = (BasketModel)controllerContext.HttpContext.Session[sessionKey];
            }

            if (basket == null)
            {
                basket = new BasketModel();
                controllerContext.HttpContext.Session[sessionKey] = basket;
            }

            return basket;
        }
    }
}