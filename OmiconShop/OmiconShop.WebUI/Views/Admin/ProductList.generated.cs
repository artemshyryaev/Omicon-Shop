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
    
    #line 2 "..\..\Views\Admin\ProductList.cshtml"
    using OmiconShop.WebUI.HtmlHelpers;

#line default
#line hidden
    using OmiconShop.WebUI;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Admin/ProductList.cshtml")]
    public partial class _Views_Admin_ProductList_cshtml : System.Web.Mvc.WebViewPage<OmiconShop.Application.Admin.ViewModel.ProductsListViewModel>
    {
        public _Views_Admin_ProductList_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Admin\ProductList.cshtml"
  
    ViewBag.Title = "Admin productList";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"panel panel-default\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n        <h3>Product list</h3>\r\n    </div>\r\n    <div>\r\n        <form");

WriteLiteral(" class=\"form-inline my-2 my-lg-0\"");

WriteLiteral(">\r\n            Find by name: ");

            
            #line 15 "..\..\Views\Admin\ProductList.cshtml"
                     Write(Html.TextBox("ProductName"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <input");

WriteLiteral(" class=\"btn btn-outline-success my-2 my-sm-0\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Search\"");

WriteLiteral(">\r\n        </form>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"table table-striped table-condensed table-bordered\"");

WriteLiteral(">\r\n            <tr>\r\n                <th>Name</th>\r\n                <th");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">Description</th>\r\n                <th");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">Image</th>\r\n                <th");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">Price</th>\r\n                <th");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">Type</th>\r\n                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Actions</th>\r\n            </tr>\r\n");

            
            #line 29 "..\..\Views\Admin\ProductList.cshtml"
            
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Admin\ProductList.cshtml"
             foreach (var el in Model.Products)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\Views\Admin\ProductList.cshtml"
               Write(Html.HiddenFor(x => el.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <td>");

            
            #line 33 "..\..\Views\Admin\ProductList.cshtml"
                   Write(Html.RouteLink(el.Name, new { controller = "Admin", action = "EditProduct", productId = el.Id }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\Admin\ProductList.cshtml"
                                      Write(el.Description);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">\r\n");

            
            #line 36 "..\..\Views\Admin\ProductList.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Admin\ProductList.cshtml"
                         if (el.ImageUrl != null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <img");

WriteLiteral(" class=\"img-thumbnail\"");

WriteLiteral(" width=\"75\"");

WriteLiteral(" height=\"75\"");

WriteAttribute("src", Tuple.Create("\r\n                                 src=\"", 1527), Tuple.Create("\"", 1579)
            
            #line 39 "..\..\Views\Admin\ProductList.cshtml"
, Tuple.Create(Tuple.Create("", 1567), Tuple.Create<System.Object, System.Int32>(el.ImageUrl
            
            #line default
            #line hidden
, 1567), false)
);

WriteLiteral(">\r\n");

            
            #line 40 "..\..\Views\Admin\ProductList.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\Admin\ProductList.cshtml"
                                      Write(el.Price);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-right\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Admin\ProductList.cshtml"
                                      Write(el.Type);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

            
            #line 45 "..\..\Views\Admin\ProductList.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\Admin\ProductList.cshtml"
                         using (Html.BeginForm("DeleteProduct", "Admin"))
                        {
                            
            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\Admin\ProductList.cshtml"
                       Write(Html.Hidden("productId", el.Id));

            
            #line default
            #line hidden
            
            #line 47 "..\..\Views\Admin\ProductList.cshtml"
                                                            

            
            #line default
            #line hidden
WriteLiteral("                            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default btn-xs\"");

WriteLiteral(" value=\"Remove\"");

WriteLiteral(">\r\n");

            
            #line 49 "..\..\Views\Admin\ProductList.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");

            
            #line 52 "..\..\Views\Admin\ProductList.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"panel-footer\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 56 "..\..\Views\Admin\ProductList.cshtml"
   Write(Html.ActionLink("Add product", "AddProduct", "Admin", new { @class = "btn btn-default" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 57 "..\..\Views\Admin\ProductList.cshtml"
   Write(Html.PageLinks(Model.PagingInfo, x => Url.Action("ProductList", new { page = x })));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
