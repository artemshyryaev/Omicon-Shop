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
    public class ReplacementTagsProcessor
    {
        StringBuilder text;
        Order order;
        TagsCreator tagsCreator;
        CreateLogFiles logFiles;

        Regex regex = new Regex(@"\[([a-zA-Z0-9]+)\]");
        Type type = typeof(Order);

        public ReplacementTagsProcessor(StringBuilder text, Order order)
        {
            this.text = text;
            this.order = order;
            logFiles = new CreateLogFiles();
            this.tagsCreator = new TagsCreator(order);
        }

        public string ProcessReplacingOrderTags()
        {
            return regex.Replace(text.ToString(), match =>
            {
                return ReplaceOrderTags(match);
            }
            );
        }

        public string ProcessReplacingBasketlineTags(BasketLine line)
        {
            return regex.Replace(text.ToString(), match =>
            {
                return ReplaceBaketLineTags(match, line);
            }
            );
        }

        string ReplaceOrderTags(Match match)
        {
            var tags = tagsCreator.CreateOrderDictionary();
            return ReplaceTags(match, tags);
        }

        string ReplaceBaketLineTags(Match match, BasketLine line)
        {
            var tags = tagsCreator.CreateBasketLineDictionary(line);
            return ReplaceTags(match, tags);
        }

        string ReplaceTags(Match match, Dictionary<string, string> tags)
        {
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