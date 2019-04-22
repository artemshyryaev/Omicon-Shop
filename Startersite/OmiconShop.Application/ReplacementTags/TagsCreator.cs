using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace OmiconShop.Application.ReplacementTags
{
    public class TagsCreator
    {
        public Dictionary<string, string> CreateMailBodyDictionary(Order order, StringBuilder basketLineText)
        {
            Dictionary<string, string> orderTags = new Dictionary<string, string>();

            orderTags.Add("[UserName]", order.User?.UserPersonalInformation?.Name);
            orderTags.Add("[Country]", order.User?.UserAddress?.Country);
            orderTags.Add("[City]", order.User?.UserAddress?.City);
            orderTags.Add("[Address]", order.User?.UserAddress?.Address);
            orderTags.Add("[Address2]", order.User?.UserAddress?.Address2);
            orderTags.Add("[ZipCode]", order.User?.UserAddress?.ZipCode);
            orderTags.Add("[Delivery]", Convert.ToString(order.OrderInformation?.Delivery));
            orderTags.Add("[Payment]", Convert.ToString(order.OrderInformation?.Payment));
            orderTags.Add("[Status]", Convert.ToString(order.Status));
            orderTags.Add("[Total]", Convert.ToString(order.OrderInformation?.Total));
            orderTags.Add("[Date]", Convert.ToString(order.OrderInformation?.Date));
            orderTags.Add("[OrderId]", Convert.ToString(order.Id));
            orderTags.Add("[Basket_Lines]", Convert.ToString(basketLineText));

            return orderTags;
        }

        public Dictionary<string, string> CreateBasketLineDictionary(BasketLine basketLine)
        {
            Dictionary<string, string> basketLineTags = new Dictionary<string, string>();

            basketLineTags.Add("[ProductName]", basketLine.Product.Name);
            basketLineTags.Add("[Qty]", Convert.ToString(basketLine.Qty));
            basketLineTags.Add("[Uom]", Convert.ToString(basketLine.Uom));
            basketLineTags.Add("[Price]", Convert.ToString(basketLine.Product.Price));

            return basketLineTags;
        }
    }
}