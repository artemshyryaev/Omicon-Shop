using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Startersite.ReplacementTags
{
    public class OrderReplacementTagsProcessor : IReplacementTagsProcessor
    {
        StringBuilder text;
        Order order;

        Regex regex = new Regex(@"\[([a-zA-Z0-9]+)\]");
        Type type = typeof(Order);

        public OrderReplacementTagsProcessor(StringBuilder text, Order order)
        {
            this.text = text;
            this.order = order;
        }

        public string Process()
        {
            return regex.Replace(text.ToString(), match =>
            {
                return ReplaceTags(match);
            }
            );
        }

        string ReplaceTags(Match match)
        {
            var replacementTagName = match.Groups[1];
            var prop = type.GetProperties().FirstOrDefault(x => x.Name.Equals(replacementTagName));

            if (prop != null)
                return prop.GetValue(order) as string;

            return match.Value;
        }
    }
}