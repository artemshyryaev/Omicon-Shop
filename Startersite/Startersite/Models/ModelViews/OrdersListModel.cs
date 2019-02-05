using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class OrdersListModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public PagingInfoModel PagingInfo { get; set; }
    }
}