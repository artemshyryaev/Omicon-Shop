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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/ChangePassword.cshtml")]
    public partial class _Views_Account_ChangePassword_cshtml : System.Web.Mvc.WebViewPage<OmiconShop.Application.Account.ViewModel.ChangePasswordViewModel>
    {
        public _Views_Account_ChangePassword_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Account\ChangePassword.cshtml"
  
    ViewBag.Title = "ChangePassword";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 8 "..\..\Views\Account\ChangePassword.cshtml"
   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h1>\r\n</hgroup>\r\n\r\n<p");

WriteLiteral(" class=\"message-success\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\Account\ChangePassword.cshtml"
                      Write(ViewBag.Message);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n<p>You\'re logged in as <strong>");

            
            #line 12 "..\..\Views\Account\ChangePassword.cshtml"
                          Write(User.Identity.Name);

            
            #line default
            #line hidden
WriteLiteral("</strong>.</p>\r\n\r\n<section");

WriteLiteral(" id=\"changePasswordForm\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\Account\ChangePassword.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Account\ChangePassword.cshtml"
     using (Html.BeginForm())
    {
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Account\ChangePassword.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Account\ChangePassword.cshtml"
                                
        
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Account\ChangePassword.cshtml"
   Write(Html.ValidationSummary(true));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Account\ChangePassword.cshtml"
                                     
        
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Account\ChangePassword.cshtml"
   Write(Html.EditorForModel());

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Account\ChangePassword.cshtml"
                              

            
            #line default
            #line hidden
WriteLiteral("        <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">\r\n");

            
            #line 21 "..\..\Views\Account\ChangePassword.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</section>\r\n");

        }
    }
}
#pragma warning restore 1591
