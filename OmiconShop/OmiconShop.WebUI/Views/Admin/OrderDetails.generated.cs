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
    
    #line 2 "..\..\Views\Admin\OrderDetails.cshtml"
    using Microsoft.AspNet.Identity;
    
    #line default
    #line hidden
    using OmiconShop.WebUI;
    using OmiconShop.WebUI.HtmlHelpers;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Admin/OrderDetails.cshtml")]
    public partial class _Views_Admin_OrderDetails_cshtml : System.Web.Mvc.WebViewPage<OmiconShop.Domain.Entities.Order>
    {
        public _Views_Admin_OrderDetails_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Admin\OrderDetails.cshtml"
  
    ViewBag.Title = "Order Details";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 9 "..\..\Views\Admin\OrderDetails.cshtml"
   Write(Model.OrderId);

            
            #line default
            #line hidden
WriteLiteral("/");

            
            #line 9 "..\..\Views\Admin\OrderDetails.cshtml"
                  Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n</hgroup>\r\n\r\n\r\n<div");

WriteLiteral(" class=\"admin-nav-menu\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 14 "..\..\Views\Admin\OrderDetails.cshtml"
Write(Html.Partial("_AdminNavMenu"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"order-info\"");

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\Admin\OrderDetails.cshtml"
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Admin\OrderDetails.cshtml"
     if (User.Identity.IsAuthenticated)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div>\r\n");

WriteLiteral("            ");

            
            #line 21 "..\..\Views\Admin\OrderDetails.cshtml"
       Write(Html.RouteLink("Go to order list page", new { controller = "Admin", action = "OrderList" }, new { @class = "badge badge-light" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 23 "..\..\Views\Admin\OrderDetails.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <table");

WriteLiteral(" class=\"table table-sm order-general-info\"");

WriteLiteral(">\r\n        <tbody>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Order no.</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\Admin\OrderDetails.cshtml"
                                 Write(Model.OrderId);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Order status</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\Admin\OrderDetails.cshtml"
                                 Write(Model.Status);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Shipping method</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\Admin\OrderDetails.cshtml"
                                 Write(Model.OrderInformation.Delivery);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Payment method</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\Admin\OrderDetails.cshtml"
                                 Write(Model.OrderInformation.Payment);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>OrderDate</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 45 "..\..\Views\Admin\OrderDetails.cshtml"
                                 Write(Model.OrderInformation.Date);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n\r\n    <table");

WriteLiteral(" class=\"table table-sm order-shipping-info\"");

WriteLiteral(">\r\n        <tbody>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Country</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 54 "..\..\Views\Admin\OrderDetails.cshtml"
                                  Write(Model.User?.UserAddress?.Country);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>City</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 58 "..\..\Views\Admin\OrderDetails.cshtml"
                                  Write(Model.User?.UserAddress?.City);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Address</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 62 "..\..\Views\Admin\OrderDetails.cshtml"
                                  Write(Model.User?.UserAddress?.Address);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Address2</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 66 "..\..\Views\Admin\OrderDetails.cshtml"
                                  Write(Model.User?.UserAddress?.Address2);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral("><b>Zip code</b></td>\r\n                <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 70 "..\..\Views\Admin\OrderDetails.cshtml"
                                  Write(Model.User?.UserAddress?.ZipCode);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n\r\n    <table");

WriteLiteral(" class=\"table table-sm order-products-info\"");

WriteLiteral(">\r\n        <thead>\r\n            <tr>\r\n                <th");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">Item no.</th>\r\n                <th");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">Title</th>\r\n                <th");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">Price</th>\r\n                <th");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">Qty</th>\r\n                <th");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">UOM</th>\r\n                <th");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">Total</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");

            
            #line 87 "..\..\Views\Admin\OrderDetails.cshtml"
            
            
            #line default
            #line hidden
            
            #line 87 "..\..\Views\Admin\OrderDetails.cshtml"
             foreach (var line in Model.BasketLine)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\Admin\OrderDetails.cshtml"
                                     Write(line.ProductId);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 91 "..\..\Views\Admin\OrderDetails.cshtml"
                                     Write(line.Product.Name);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 92 "..\..\Views\Admin\OrderDetails.cshtml"
                                      Write((double)line.Product.Price);

            
            #line default
            #line hidden
WriteLiteral("$</td>\r\n                    <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 93 "..\..\Views\Admin\OrderDetails.cshtml"
                                     Write(line.Qty);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\Admin\OrderDetails.cshtml"
                                     Write(line.Uom);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-left\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\Admin\OrderDetails.cshtml"
                                      Write(line.Qty * (double)line.Product.Price);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                </tr>\r\n");

            
            #line 97 "..\..\Views\Admin\OrderDetails.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n        <tfoot>\r\n            <tr>\r\n                <td");

WriteLiteral(" colspan=\"5\"");

WriteLiteral(" class=\"order-total\"");

WriteLiteral("><b>Total:</b> ");

            
            #line 101 "..\..\Views\Admin\OrderDetails.cshtml"
                                                             Write(Model.OrderInformation.Total);

            
            #line default
            #line hidden
WriteLiteral(" $</td>\r\n    </table>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"order-operations\"");

WriteLiteral(">\r\n");

            
            #line 106 "..\..\Views\Admin\OrderDetails.cshtml"
    
            
            #line default
            #line hidden
            
            #line 106 "..\..\Views\Admin\OrderDetails.cshtml"
     if (User.Identity.Name == "admin@gmail.com" && Model.Status == OmiconShop.Domain.Enumerations.OrderStatuses.Pending)
    {
        
            
            #line default
            #line hidden
            
            #line 108 "..\..\Views\Admin\OrderDetails.cshtml"
   Write(Html.RouteLink("Approve order", new { action = "Approve", controller = "Admin", orderId = Model.OrderId },
            new { @class = "btn btn-primary" }));

            
            #line default
            #line hidden
            
            #line 109 "..\..\Views\Admin\OrderDetails.cshtml"
                                               
        
            
            #line default
            #line hidden
            
            #line 110 "..\..\Views\Admin\OrderDetails.cshtml"
   Write(Html.RouteLink("Decline order", new { action = "Decline", controller = "Admin", orderId = Model.OrderId },
            new { @class = "btn btn-danger decline-order-btn" }));

            
            #line default
            #line hidden
            
            #line 111 "..\..\Views\Admin\OrderDetails.cshtml"
                                                                
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
