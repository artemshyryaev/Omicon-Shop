﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using OmiconShop.WebUI;
    using OmiconShop.WebUI.HtmlHelpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_AdminLayout.cshtml")]
    public partial class _Views_Shared__AdminLayout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__AdminLayout_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Shared\_AdminLayout.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0\"");

WriteLiteral(">\r\n    <title>");

            
            #line 11 "..\..\Views\Shared\_AdminLayout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n");

WriteLiteral("    ");

            
            #line 12 "..\..\Views\Shared\_AdminLayout.cshtml"
Write(Styles.Render("~/wwwroot/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 13 "..\..\Views\Shared\_AdminLayout.cshtml"
Write(Scripts.Render("~/bundles/modernizr"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 14 "..\..\Views\Shared\_AdminLayout.cshtml"
Write(Scripts.Render("~/bundles/jquery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 15 "..\..\Views\Shared\_AdminLayout.cshtml"
Write(Scripts.Render("~/bundles/bootstrap"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 16 "..\..\Views\Shared\_AdminLayout.cshtml"
Write(Scripts.Render("~/bundles/sitejs"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body>\r\n    <header>\r\n");

WriteLiteral("        ");

            
            #line 20 "..\..\Views\Shared\_AdminLayout.cshtml"
   Write(Html.Partial("_NavBar", new OmiconShop.Application.Account.ViewModel.LoginViewModel()));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </header>\r\n\r\n");

            
            #line 23 "..\..\Views\Shared\_AdminLayout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\_AdminLayout.cshtml"
     if (User.Identity.IsAuthenticated)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div>\r\n");

WriteLiteral("            ");

            
            #line 26 "..\..\Views\Shared\_AdminLayout.cshtml"
       Write(Html.RouteLink("Personal information", new { controller = "Admin", action = "PersonalInfo" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\Shared\_AdminLayout.cshtml"
       Write(Html.RouteLink("Orders", new { controller = "Admin", action = "OrderList" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 29 "..\..\Views\Shared\_AdminLayout.cshtml"
            
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\_AdminLayout.cshtml"
             if (User.Identity.Name == "admin@gmail.com")
            {
                
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Shared\_AdminLayout.cshtml"
           Write(Html.RouteLink("Products", new { controller = "Admin", action = "ProductList" }));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Shared\_AdminLayout.cshtml"
                                                                                                 
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n");

            
            #line 34 "..\..\Views\Shared\_AdminLayout.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <div>\r\n");

            
            #line 37 "..\..\Views\Shared\_AdminLayout.cshtml"
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Shared\_AdminLayout.cshtml"
         if (TempData["message"] != null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"alert alert-success\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Shared\_AdminLayout.cshtml"
                                        Write(TempData["message"]);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 40 "..\..\Views\Shared\_AdminLayout.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 41 "..\..\Views\Shared\_AdminLayout.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <footer>\r\n");

WriteLiteral("        ");

            
            #line 45 "..\..\Views\Shared\_AdminLayout.cshtml"
   Write(Html.Partial("_Footer"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </footer>\r\n\r\n");

WriteLiteral("    ");

            
            #line 48 "..\..\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
