using OmiconShop.Domain.Entities;
using Startersite.IManagers;
using Startersite.Models;
using Startersite.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Managers
{
    public class ProductManager
    {
        IProductRepositoryы productsRepo;

        public ProductManager(IProductRepositoryы productsRepo)
        {
            this.productsRepo = productsRepo;
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize, string type = null, string productName = null)
        {
            if (string.IsNullOrEmpty(type) && string.IsNullOrEmpty(productName))
                return productsRepo.Products.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                     products => products.Id);
            else if (string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(type))
                return productsRepo.Products.Where(p => p.Type == type).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id);
            else if (!string.IsNullOrEmpty(productName) && string.IsNullOrEmpty(type))
                return productsRepo.Products.Where(p => p.Name.Contains(productName)).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id);
            else
                return productsRepo.Products.Where(p => p.Type == type && p.Name.Contains(productName)).Skip((page - 1) * pageSize).Take(
                    pageSize).OrderBy(products => products.Id);
        }
    }
}