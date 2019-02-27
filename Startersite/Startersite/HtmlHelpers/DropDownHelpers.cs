using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Startersite.HtmlHelpers
{
    public static class DropDownHelpers
    {
        public static MvcHtmlString EnumDropdownListFor<TModel, TProperty, TEnum>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum selectedValue)
        {
            var values = new[] { "All" }.Concat(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => v.ToString()));

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem()
                                                {
                                                    Text = value.ToString(),
                                                    Value = value.ToString(),
                                                    Selected = (value.Equals(selectedValue))
                                                };

            return SelectExtensions.DropDownListFor(htmlHelper, expression, items);
        }

        public static MvcHtmlString UomEnumDropdownList<TModel, TProperty, TEnum>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum selectedValue, object htmlAttributes)
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem()
                                                {
                                                    Text = value.ToString(),
                                                    Value = value.ToString(),
                                                    Selected = (value.Equals(selectedValue))
                                                };

            return SelectExtensions.DropDownListFor(htmlHelper, expression, items, htmlAttributes);
        }
    }
}