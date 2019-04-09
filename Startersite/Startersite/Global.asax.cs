using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Startersite.Filters;
using Startersite.Infrastructure;
using Startersite.Models.ViewModel;

namespace Startersite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(BasketViewModel), new BasketModelBinder());
            GlobalFilters.Filters.Add(new InitializeSimpleMembershipAttribute());
        }
    }
}
