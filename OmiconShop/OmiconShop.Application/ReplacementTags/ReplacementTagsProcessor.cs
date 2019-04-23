using OmiconShop.Application.Logs;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace OmiconShop.Application.ReplacementTags
{
    public class ReplacementTagsProcessor
    {
        Regex regex = new Regex(@"\[([a-zA-Z0-9]+)\]");

        public StringBuilder GetReplacedText(Order order)
        {
            var resourceReader = new ResourceReader();
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
            emailBodyResourceValue.Append(resourceReader
                .GetResourceValueByKey(Resources.MailTemplate.OrderConfirmation_Body));

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
            basketLineResourceValue.Append(resourceReader
                .GetResourceValueByKey(Resources.MailTemplate.OrderConfirmation_BasketLines));

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