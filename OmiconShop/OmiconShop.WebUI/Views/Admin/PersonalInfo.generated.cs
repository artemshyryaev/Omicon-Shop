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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Admin/PersonalInfo.cshtml")]
    public partial class _Views_Admin_PersonalInfo_cshtml : System.Web.Mvc.WebViewPage<OmiconShop.Application.Admin.ViewModel.UserViewModel>
    {
        public _Views_Admin_PersonalInfo_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Admin\PersonalInfo.cshtml"
  
    ViewBag.Title = "Your personal details";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 7 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n</hgroup>\r\n\r\n<div");

WriteLiteral(" class=\"admin-nav-menu\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 11 "..\..\Views\Admin\PersonalInfo.cshtml"
Write(Html.Partial("_AdminNavMenu"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

            
            #line 14 "..\..\Views\Admin\PersonalInfo.cshtml"
 using (Html.BeginForm("PersonalInfo", "Admin"))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"change-password\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 17 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(Html.ValidationSummary(true));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 18 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 19 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(Html.HiddenFor(x => x.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 20 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(Html.LabelFor(x => x.Email, new { @class = "email-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 21 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(Html.TextBoxFor(x => x.Email, new { @class = "form-control email-textbox" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Admin\PersonalInfo.cshtml"
   Write(Html.ValidationMessageFor(x => x.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Save changes\"");

WriteLiteral(" class=\"btn btn-primary submit-personal-info\"");

WriteLiteral(">\r\n    </div>\r\n");

            
            #line 25 "..\..\Views\Admin\PersonalInfo.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
