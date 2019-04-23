using OmiconShop.Application.Admin.ViewModel;
using System;
using System.Text;
using System.Web.Mvc;

namespace OmiconShop.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfoViewModel pagingInfo, Func<int, string> pageUrl)
        {
            var builder = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var tag = new TagBuilder("a");
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