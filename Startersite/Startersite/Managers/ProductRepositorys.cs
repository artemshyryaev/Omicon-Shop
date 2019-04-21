using OmiconShop.Domain.Entities;
using OmiconShop.Persistence;
using Startersite.IManagers;
using System.Collections.Generic;

namespace Startersite.Managers
{
    public class ProductRepositorys : IProductRepositoryы
    {
        ShopDBContext context = new ShopDBContext();

        public IEnumerable<Product> Products { get { return context.Products; } }
    }
}