using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class ProductsListModel
    {
        public IEnumerable<Products> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}