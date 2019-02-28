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
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum? selectedValue) where TEnum : struct
        {
            var stringified = selectedValue != null ? selectedValue.Value.ToString() : null;
            var values = new[] { "All" }.Concat(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => v.ToString()));
            IEnumerable<SelectListItem> items = ValueToListItems(stringified, values);

            return SelectExtensions.DropDownListFor(htmlHelper, expression, items);
        }

        public static MvcHtmlString UomEnumDropdownList<TModel, TEnum>(
            this HtmlHelper<TModel> htmlHelper, string name, TEnum selectedValue, object htmlAttributes) where TEnum : struct
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            IEnumerable<SelectListItem> items = ValueToListItems(selectedValue, values);

            return SelectExtensions.DropDownList(htmlHelper, name, items, htmlAttributes);
        }

        public static MvcHtmlString UomEnumDropdownList<TModel, TEnum>(
            this HtmlHelper<TModel> htmlHelper, string name, TEnum? selectedValue, object htmlAttributes) where TEnum : struct
        {
            var stringified = selectedValue != null ? selectedValue.Value.ToString() : null;
            var values = new[] { "---" }.Concat(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => v.ToString()));
            IEnumerable<SelectListItem> items = ValueToListItems(stringified, values);

            return SelectExtensions.DropDownList(htmlHelper, name, items, htmlAttributes);
        }

        private static IEnumerable<SelectListItem> ValueToListItems<TValue>(TValue stringified, IEnumerable<TValue> values)
        {
            return from value in values
                   select new SelectListItem()
                   {
                       Text = value.ToString(),
                       Value = value.ToString(),
                       Selected = (value.Equals(stringified))
                   };
        }

    }
}