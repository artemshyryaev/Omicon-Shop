using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using Startersite.IManagers;
using System.Collections.Generic;

namespace Startersite.Managers
{
    public class ProductRepository : IProductRepository
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Product> Products { get { return context.Products; } }
    }
}