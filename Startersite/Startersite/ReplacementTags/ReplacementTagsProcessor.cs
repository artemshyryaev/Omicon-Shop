using Startersite.Logs;
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
        TagsCreator tagsCreator;
        CreateLogFiles logFiles;

        Regex regex = new Regex(@"\[([a-zA-Z0-9]+)\]");
        Type type = typeof(Order);

        public OrderReplacementTagsProcessor(StringBuilder text, Order order)
        {
            this.text = text;
            this.order = order;
            logFiles = new CreateLogFiles();
            this.tagsCreator = new TagsCreator(order);
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
            var tags = tagsCreator.CreateDictionary();
            string replacementTagName = Convert.ToString(match.Groups[1]);
            try
            {
                return tags[replacementTagName];
            }
            catch (KeyNotFoundException ex)
            {
                logFiles.CreateErrorLog(ex.Message);
                return match.Value;
            }
        }
    }
}