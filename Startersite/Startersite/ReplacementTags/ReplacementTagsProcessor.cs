using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Startersite.ReplacementTags
{
    public class OrderReplacementTagsProcessor : IReplacementTagsProcessor
    {
        Dictionary<string, TagReplacer> tagReplacers;
        StringBuilder text;
        Order order;

        Regex regex = new Regex("^[a-z]+$|^[A-Z]+$|^[A-Z0-9]+$|^[a-z0-9]+$");

        Type type = typeof(Order);

        public OrderReplacementTagsProcessor(StringBuilder text, Order order)
        {
            this.text = text;
            this.order = order;
        }

        public string Process()
        {
            return Regex.Replace(text, regex, match =>
           {
               foreach (PropertyInfo prop in type.GetProperties())
               {
                   if (prop.Equals(match.Value))
                   {
                       return prop.Name;
                   }
                   break;
               }
               return;
           }
            );
        }

        public object GetType(object obj)
        {
            return typeof(obj);
        }

        public string ReplaceTags(Match m)
        {

        }
    }
}