using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OmiconShop.WebUI.HtmlHelpers
{
    public static class ElementAttributesHelpers
    {
        public static string IsActive<TModel>(this HtmlHelper<TModel> htmlHelper, string controller, string action)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeController = routeData.Values["controller"].ToString();
            var routeAction = routeData.Values["action"].ToString();

            if ((controller == routeController && action == routeAction)
                || (routeAction == "EditProduct" && action == "ProductList")
                || (routeAction == "OrderDetails" && action == "OrderList"))
                return "nav-link active";
            else
                return "nav-link";;
        }
    }
}