using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class OrdersListModel
    {
        public IEnumerable<Orders> Orders { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}