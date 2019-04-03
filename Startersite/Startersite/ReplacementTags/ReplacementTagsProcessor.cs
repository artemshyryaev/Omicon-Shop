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
         Dictionary<string, TagReplacer> tagReplacers;
        StringBuilder text;
        Order order;

        Regex regex = new Regex();

        public OrderReplacementTagsProcessor(StringBuilder text, Order order)
        {
            this.text = text;
            this.order = order;
        }

        public string Process()
        {
            return regex.Replace(text, match =>
           {
               return 
           }
            );
        }

        public string ReplaceTags(Match m)
        {

        }
    }
}