using System.Web;
using System.Web.Optimization;

namespace OmiconShop.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/wwwroot/lib/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/wwwroot/lib/jquery-validate/jquery.validate*",
                        "~/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/wwwroot/lib/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/wwwroot/lib/bootstrap/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/wwwroot/css").Include(
                      "~/wwwroot/lib/bootstrap/css/bootstrap.css",
                      "~/wwwroot/css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                "~/wwwroot/js/Site.js"));
        }
    }
}
