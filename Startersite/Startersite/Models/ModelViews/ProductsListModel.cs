using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class ProductsListModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfoModel PagingInfo { get; set; }

        public string Type { get; set; }
    }
}