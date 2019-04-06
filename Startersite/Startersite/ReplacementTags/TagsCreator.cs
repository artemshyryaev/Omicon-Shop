using Startersite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Startersite.ReplacementTags
{
    public class TagsCreator
    {
        Order order;
        ResourceReader resourceReader;

        public TagsCreator(Order order)
        {
            this.order = order;
            this.resourceReader = new ResourceReader("Startersite.Resources");
        }

        public Dictionary<string, string> CreateOrderDictionary()
        {
            Dictionary<string, string> orderTags = new Dictionary<string, string>();

            orderTags.Add("[UserName]", order.OrderInformation?.Name);
            orderTags.Add("[Country]", order.OrderInformation?.Country);
            orderTags.Add("[Address]", order.OrderInformation?.Address);
            orderTags.Add("[Address2]", order.OrderInformation?.Address2);
            orderTags.Add("[City]", order.OrderInformation?.City);
            orderTags.Add("[ZipCode]", order.OrderInformation?.ZipCode);
            orderTags.Add("[Delivery]", Convert.ToString(order.OrderInformation?.Delivery));
            orderTags.Add("[Payment]", Convert.ToString(order.OrderInformation?.Payment));
            orderTags.Add("[Status]", Convert.ToString(order.Status));
            orderTags.Add("[Total]", Convert.ToString(order.Total));
            orderTags.Add("[Date]", Convert.ToString(order.Date));
            orderTags.Add("[OrderId]", Convert.ToString(order.Id));
            orderTags.Add("[Basket_Lines]", ReplaceBasketLinesTags());

            return orderTags;
        }

        public Dictionary<string, string> CreateBasketLineDictionary(BasketLine basketLine)
        {
            Dictionary<string, string> basketLineTags = new Dictionary<string, string>();

            basketLineTags.Add("[ProductName]", basketLine.ProductName);
            basketLineTags.Add("[Qty]", Convert.ToString(basketLine.Qty));
            basketLineTags.Add("[Uom]", Convert.ToString(basketLine.Uom));
            basketLineTags.Add("[Price]", Convert.ToString(basketLine.Price));

            return basketLineTags;
        }

        string ReplaceBasketLinesTags()
        {
            string text = null;

            foreach (var line in order.BasketLine)
            {
                string textWithReplacementTags = resourceReader.GetResourceValueByKey("Basket_Lines");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(textWithReplacementTags);
                ReplacementTagsProcessor replacementTagsProcessor =
                    new ReplacementTagsProcessor(sb, order);
                text += replacementTagsProcessor.ProcessReplacingBasketlineTags(line);
            }

            return text;
        }
    }
}