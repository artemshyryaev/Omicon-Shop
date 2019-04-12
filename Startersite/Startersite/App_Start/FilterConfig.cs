using Startersite.Filters;
using System.Web;
using System.Web.Mvc;

namespace Startersite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
