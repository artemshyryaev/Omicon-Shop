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
        Dictionary<string, string> tags;
        Order order;

        public TagsCreator(Order order)
        {
            tags = new Dictionary<string, string>();
            this.order = order;
        }

        public Dictionary<string, string> CreateDictionary()
        {
            tags.Add("[UserName]", order.OrderInformation?.Name);
            tags.Add("[Country]", order.OrderInformation?.Country);
            tags.Add("[Address]", order.OrderInformation?.Address);
            tags.Add("[Address2]", order.OrderInformation?.Address2);
            tags.Add("[City]", order.OrderInformation?.City);
            tags.Add("[ZipCode]", order.OrderInformation?.ZipCode);
            tags.Add("[Delivery]", Convert.ToString(order.OrderInformation?.Delivery));
            tags.Add("[Payment]", Convert.ToString(order.OrderInformation?.Payment));
            tags.Add("[Status]", Convert.ToString(order.Status));
            tags.Add("[Total]", Convert.ToString(order.Total));
            tags.Add("[Date]", Convert.ToString(order.Date));
            tags.Add("[OrderId]", Convert.ToString(order.Id));
            tags.Add("[Basket_Lines]", BasketLinesData());

            return tags;
        }

        string BasketLinesData()
        {
            throw new NotImplementedException();
        }
    }
}