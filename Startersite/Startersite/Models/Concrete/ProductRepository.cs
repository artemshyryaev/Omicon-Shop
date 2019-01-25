using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite
{
    public class ProductRepository : IProductRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Products> Products { get { return context.Products; } }
    }
}