using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmiconShop.WebUI.HelperAttributes
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
                base.OnAuthorization(filterContext);
            else
                filterContext.Result = new RedirectResult("~/Home/Index");
        }
    }
}