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
        Regex regex = new Regex(@"\[([a-zA-Z0-9]+)\]");

        public StringBuilder GetReplacedText(Order order)
        {
            var resourceReader = new ResourceReader("Startersite.MailTemplate");
            StringBuilder replacedText = new StringBuilder();

            foreach (var line in order.BasketLine)
            {
                ReplaceBasketLineTags(resourceReader, replacedText, line);
            }

            return ReplaceMailBodyTags(order, resourceReader, replacedText);
        }

        StringBuilder ReplaceMailBodyTags(Order order, ResourceReader resourceReader, StringBuilder replacedText)
        {
            StringBuilder emailBodyResourceValue = new StringBuilder();
            emailBodyResourceValue.Append(resourceReader.GetResourceValueByKey("OrderConfirmation_Body"));

            TagsCreator emailBodyTagsCreator = new TagsCreator();
            var orderDictionary = emailBodyTagsCreator.CreateMailBodyDictionary(order, replacedText);
            replacedText.Clear();

            return replacedText.Append(regex.Replace(emailBodyResourceValue.ToString(), match =>
            {
                return ReplaceTags(match, orderDictionary);
            }
            ));
        }

        void ReplaceBasketLineTags(ResourceReader resourceReader, StringBuilder replacedText, BasketLine line)
        {
            StringBuilder basketLineResourceValue = new StringBuilder();
            basketLineResourceValue.Append(resourceReader.GetResourceValueByKey("Basket_Lines"));

            TagsCreator basketLineTagsCreator = new TagsCreator();
            var lineDictionary = basketLineTagsCreator.CreateBasketLineDictionary(line);

            replacedText.Append(regex.Replace(basketLineResourceValue.ToString(), match =>
            {
                return ReplaceTags(match, lineDictionary);
            }
            ));
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
                CreateLogFiles logFiles = new CreateLogFiles();
                logFiles.CreateErrorLog(ex.Message);
                return match.Value;
            }
        }
    }
}