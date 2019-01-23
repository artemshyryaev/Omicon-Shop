using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite
{
    public class ProductRepository : IProductRepository
    {
        DentDbContext context = new DentDbContext();

        public IEnumerable<Products> Products { get { return context.Products; } }
    }
}