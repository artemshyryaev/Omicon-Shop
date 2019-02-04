using Startersite.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.Abstract
{
    public interface IOrderProcessor
    {
        Orders ProcessOrder(BasketModel basket, OrderInformation orderInformation);
    }
}