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
    
    #line 2 "..\..\Views\Admin\OrderList.cshtml"
    using OmiconShop.WebUI.HtmlHelpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Admin/OrderList.cshtml")]
    public partial class _Views_Admin_OrderList_cshtml : System.Web.Mvc.WebViewPage<OmiconShop.Application.Admin.ViewModel.OrdersViewModel>
    {
        public _Views_Admin_OrderList_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Admin\OrderList.cshtml"
  
    ViewBag.Title = "OrdersList";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 9 "..\..\Views\Admin\OrderList.cshtml"
   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n</hgroup>\r\n\r\n<div");

WriteLiteral(" class=\"panel panel-default row justify-content-between\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"admin-nav-menu col-1\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 14 "..\..\Views\Admin\OrderList.cshtml"
   Write(Html.Partial("_AdminNavMenu"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"admin-product-table col\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"admin-orders-search-control\"");

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\Admin\OrderList.cshtml"
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Admin\OrderList.cshtml"
             using (Html.BeginForm("OrderList", "Admin", FormMethod.Get, new { @class = "form-inline my-2 my-lg-0 admin-orders-filter" }))
            {
                
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Admin\OrderList.cshtml"
           Write(Html.EnumDropdownListFor(x => x.SelectedStatus, Model.SelectedStatus, new { @class = "form-control" }));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Admin\OrderList.cshtml"
                                                                                                                       

            
            #line default
            #line hidden
WriteLiteral("                <button");

WriteLiteral(" class=\"btn btn-outline-success my-2 my-sm-0\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(">Search</button>\r\n");

            
            #line 22 "..\..\Views\Admin\OrderList.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 24 "..\..\Views\Admin\OrderList.cshtml"
            
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Admin\OrderList.cshtml"
             using (Html.BeginForm("OrderList", "Admin", FormMethod.Get, new { @class = "form-inline my-2 my-lg-0 admin-orders-search" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <input");

WriteLiteral(" class=\"form-control mr-sm-2\"");

WriteLiteral(" type=\"search\"");

WriteLiteral(" placeholder=\"Find by order no...\"");

WriteLiteral(" aria-label=\"Search\"");

WriteLiteral(" name=\"productName\"");

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" class=\"btn btn-outline-success my-2 my-sm-0\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(">Search</button>\r\n");

            
            #line 28 "..\..\Views\Admin\OrderList.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" class=\"table table-striped admin-orders-table\"");

WriteLiteral(">\r\n                    <tr>\r\n                        <th>Order no.</th>\r\n        " +
"                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Order date</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Bill-to name</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Total</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Order Status</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Actions</th>\r\n                    </tr>\r\n");

            
            #line 40 "..\..\Views\Admin\OrderList.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 40 "..\..\Views\Admin\OrderList.cshtml"
                     foreach (var el in Model.Orders)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td>");

            
            #line 43 "..\..\Views\Admin\OrderList.cshtml"
                           Write(el.OrderId);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 44 "..\..\Views\Admin\OrderList.cshtml"
                                               Write(el.OrderInformation.Date);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 45 "..\..\Views\Admin\OrderList.cshtml"
                                                Write(el.User.UserPersonalInformation.Name + " " + el.User.UserPersonalInformation.Surname);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 46 "..\..\Views\Admin\OrderList.cshtml"
                                               Write(el.OrderInformation.Total);

            
            #line default
            #line hidden
WriteLiteral(" $</td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 47 "..\..\Views\Admin\OrderList.cshtml"
                                               Write(el.Status);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 48 "..\..\Views\Admin\OrderList.cshtml"
                                               Write(Html.RouteLink("View details", new { controller = "Admin", action = "OrderDetails", orderId = el.OrderId }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        </tr>\r\n");

            
            #line 50 "..\..\Views\Admin\OrderList.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n<nav>\r\n" +
"    <input");

WriteLiteral(" class=\"current-page\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2707), Tuple.Create("\"", 2744)
            
            #line 56 "..\..\Views\Admin\OrderList.cshtml"
, Tuple.Create(Tuple.Create("", 2715), Tuple.Create<System.Object, System.Int32>(Model.PagingInfo.CurrentPage
            
            #line default
            #line hidden
, 2715), false)
);

WriteLiteral(">\r\n    <input");

WriteLiteral(" class=\"total-pages\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2792), Tuple.Create("\"", 2828)
            
            #line 57 "..\..\Views\Admin\OrderList.cshtml"
, Tuple.Create(Tuple.Create("", 2800), Tuple.Create<System.Object, System.Int32>(Model.PagingInfo.TotalPages
            
            #line default
            #line hidden
, 2800), false)
);

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"pagination justify-content-end\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 59 "..\..\Views\Admin\OrderList.cshtml"
   Write(Html.PageLinks(Model.PagingInfo, x => Url.Action("ProductsList", new { page = x })));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </ul>\r\n</nav>");

        }
    }
}
#pragma warning restore 1591
