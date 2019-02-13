using Startersite.IManagers;
using Startersite.Models;
using System.Collections.Generic;
using System.Linq;

namespace Startersite.Managers
{
    public class ProductManager
    {
        IProductRepository productsRepo;

        public ProductManager(IProductRepository productsRepo) 
        {
            this.productsRepo = productsRepo;
        }

        public IEnumerable<Product> GetProducts(string type, int page, int pageSize)
        {
            if (type == null)
               return productsRepo.Products.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id);
            else
                return productsRepo.Products.Where(p => p.Type == type).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id);
        }
    }
}