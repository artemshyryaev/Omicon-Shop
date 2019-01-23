using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Startersite.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("bt-primary");
                }

                tag.AddCssClass("btn btn-default");
                builder.Append(tag.ToString());
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}