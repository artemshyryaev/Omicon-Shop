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

            CreatePreviousPageLink(pagingInfo, pageUrl, builder);
            CreatePageLinks(pagingInfo, pageUrl, builder);
            CreateNextPageLink(pagingInfo, pageUrl, builder);

            return MvcHtmlString.Create(builder.ToString());
        }

        private static void CreatePageLinks(PagingInfoViewModel pagingInfo, Func<int, string> pageUrl, StringBuilder builder)
        {
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var listElement = new TagBuilder("li");
                var link = new TagBuilder("a");

                link.MergeAttribute("href", pageUrl(i));
                link.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                    listElement.AddCssClass("active");

                link.AddCssClass("page-link");
                listElement.AddCssClass("page-item");
                listElement.InnerHtml += link;

                builder.Append(listElement.ToString());
            }
        }

        private static void CreateNextPageLink(PagingInfoViewModel pagingInfo, Func<int, string> pageUrl, StringBuilder builder)
        {
            var listElement = new TagBuilder("li");
            listElement.AddCssClass("page-item");

            var nextPageLink = new TagBuilder("a");
            nextPageLink.AddCssClass("page-link link-nt");
            nextPageLink.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
            nextPageLink.MergeAttribute("aria-label", "Next");

            var firstSpan = new TagBuilder("span");
            firstSpan.MergeAttribute("aria-hidden", "true");
            firstSpan.InnerHtml += "&raquo;";

            var secondSpan = new TagBuilder("span");
            secondSpan.AddCssClass("sr-only");
            secondSpan.InnerHtml += "Next";

            nextPageLink.InnerHtml += firstSpan;
            nextPageLink.InnerHtml += secondSpan;

            listElement.InnerHtml += nextPageLink;

            builder.Append(listElement.ToString());
        }

        private static void CreatePreviousPageLink(PagingInfoViewModel pagingInfo, Func<int, string> pageUrl, StringBuilder builder)
        {
            var listElement = new TagBuilder("li");
            listElement.AddCssClass("page-item");

            var previousLinkPage = new TagBuilder("a");
            previousLinkPage.AddCssClass("page-link link-pr");
            previousLinkPage.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
            previousLinkPage.MergeAttribute("aria-label", "Previous");

            var firstSpan = new TagBuilder("span");
            firstSpan.MergeAttribute("aria-hidden", "true");
            firstSpan.InnerHtml += "&laquo;";

            var secondSpan = new TagBuilder("span");
            secondSpan.AddCssClass("sr-only");
            secondSpan.InnerHtml += "Previous";

            previousLinkPage.InnerHtml += firstSpan;
            previousLinkPage.InnerHtml += secondSpan;

            listElement.InnerHtml += previousLinkPage;

            builder.Append(listElement.ToString());
        }
    }
}