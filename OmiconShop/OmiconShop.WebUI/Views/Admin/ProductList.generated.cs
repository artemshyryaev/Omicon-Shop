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
    
    #line 2 "..\..\Views\Admin\ProductList.cshtml"
    using OmiconShop.WebUI.HtmlHelpers;
    
    #line default
    #line hidden
    
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
  
    ViewBag.Title = "Product list";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<hgroup");

WriteLiteral(" class=\"title\"");

WriteLiteral(">\r\n    <h1>");

            
            #line 9 "..\..\Views\Admin\ProductList.cshtml"
   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n</hgroup>\r\n\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-2\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 14 "..\..\Views\Admin\ProductList.cshtml"
   Write(Html.Partial("_AdminNavMenu"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"admin-product-table col-10\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"admin-product-search-control\"");

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\Admin\ProductList.cshtml"
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Admin\ProductList.cshtml"
             using (Html.BeginForm("ProductList", "Admin", FormMethod.Get, new { @class = "form-inline my-2 my-lg-0 admin-product-search" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <input");

WriteLiteral(" class=\"form-control mr-sm-2\"");

WriteLiteral(" type=\"search\"");

WriteLiteral(" placeholder=\"Find by name...\"");

WriteLiteral(" aria-label=\"Search\"");

WriteLiteral(" name=\"productName\"");

WriteLiteral(" />\r\n");

WriteLiteral("                <button");

WriteLiteral(" class=\"btn btn-outline-success my-2 my-sm-0\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(">Search</button>\r\n");

            
            #line 22 "..\..\Views\Admin\ProductList.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\Admin\ProductList.cshtml"
       Write(Html.ActionLink("Add new product", "AddProduct", "Admin", new { @class = "btn btn-primary add-admin-product" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" class=\"table table-striped admin-product-table__table\"");

WriteLiteral(">\r\n                <tr>\r\n                    <th>Name</th>\r\n                    <" +
"th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Description</th>\r\n                    <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Image</th>\r\n                    <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Price</th>\r\n                    <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Type</th>\r\n                    <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">Actions</th>\r\n                </tr>\r\n");

            
            #line 36 "..\..\Views\Admin\ProductList.cshtml"
                
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Admin\ProductList.cshtml"
                 foreach (var el in Model.Products)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr");

WriteAttribute("class", Tuple.Create(" class=\"", 1542), Tuple.Create("\"", 1567)
, Tuple.Create(Tuple.Create("", 1550), Tuple.Create("row-", 1550), true)
            
            #line 38 "..\..\Views\Admin\ProductList.cshtml"
, Tuple.Create(Tuple.Create("", 1554), Tuple.Create<System.Object, System.Int32>(el.ProductId
            
            #line default
            #line hidden
, 1554), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 39 "..\..\Views\Admin\ProductList.cshtml"
                   Write(Html.HiddenFor(x => el.ProductId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <td>");

            
            #line 40 "..\..\Views\Admin\ProductList.cshtml"
                       Write(Html.RouteLink(el.Name, new { controller = "Admin", action = "EditProduct", id = el.ProductId }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\Admin\ProductList.cshtml"
                                           Write(el.Description);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

            
            #line 43 "..\..\Views\Admin\ProductList.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 43 "..\..\Views\Admin\ProductList.cshtml"
                             if (el.ImageUrl != null)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <img");

WriteLiteral(" class=\"img-thumbnail\"");

WriteLiteral(" width=\"75\"");

WriteLiteral(" height=\"75\"");

WriteAttribute("src", Tuple.Create("\r\n                                     src=\"", 2050), Tuple.Create("\"", 2106)
            
            #line 46 "..\..\Views\Admin\ProductList.cshtml"
, Tuple.Create(Tuple.Create("", 2094), Tuple.Create<System.Object, System.Int32>(el.ImageUrl
            
            #line default
            #line hidden
, 2094), false)
);

WriteLiteral(">\r\n");

            
            #line 47 "..\..\Views\Admin\ProductList.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 49 "..\..\Views\Admin\ProductList.cshtml"
                                            Write((double)el.Price);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 50 "..\..\Views\Admin\ProductList.cshtml"
                                           Write(el.Type);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 52 "..\..\Views\Admin\ProductList.cshtml"
                       Write(Html.RouteLink(" ", new { controller = "Admin", action = "EditProduct", id = el.ProductId }
                                , new { @class = "fas fa-pen-square" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"link-delete fas fa-trash\"");

WriteLiteral(" data-id=\"");

            
            #line 54 "..\..\Views\Admin\ProductList.cshtml"
                                                                             Write(el.ProductId);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("></a>\r\n                        </td>\r\n                    </tr>\r\n");

            
            #line 57 "..\..\Views\Admin\ProductList.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n<nav>\r\n    <input");

WriteLiteral(" class=\"current-page\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2844), Tuple.Create("\"", 2881)
            
            #line 63 "..\..\Views\Admin\ProductList.cshtml"
, Tuple.Create(Tuple.Create("", 2852), Tuple.Create<System.Object, System.Int32>(Model.PagingInfo.CurrentPage
            
            #line default
            #line hidden
, 2852), false)
);

WriteLiteral(">\r\n    <input");

WriteLiteral(" class=\"total-pages\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2929), Tuple.Create("\"", 2965)
            
            #line 64 "..\..\Views\Admin\ProductList.cshtml"
, Tuple.Create(Tuple.Create("", 2937), Tuple.Create<System.Object, System.Int32>(Model.PagingInfo.TotalPages
            
            #line default
            #line hidden
, 2937), false)
);

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"pagination justify-content-end\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 66 "..\..\Views\Admin\ProductList.cshtml"
   Write(Html.PageLinks(Model.PagingInfo, x => Url.Action("ProductsList", new { page = x, type = Model.Type })));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </ul>\r\n</nav>\r\n");

        }
    }
}
#pragma warning restore 1591
