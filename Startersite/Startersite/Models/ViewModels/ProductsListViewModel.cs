using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ViewModel
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfoViewModel PagingInfo { get; set; }

        public string Type { get; set; }
    }
}