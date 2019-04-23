using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Home.Operations
{
    public class ProductOperations
    {
        IProductRepository productRepository;

        public ProductOperations(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize, string type = null, string productName = null)
        {
            var allProducts = productRepository.GetAllProducts();

            if (string.IsNullOrEmpty(type) && string.IsNullOrEmpty(productName))
                return allProducts.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                     products => products.Id).ToList();
            else if (string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(type))
                return allProducts.Where(p => p.Type == type).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id).ToList();
            else if (!string.IsNullOrEmpty(productName) && string.IsNullOrEmpty(type))
                return allProducts.Where(p => p.Name.Contains(productName)).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id).ToList();
            else
                return allProducts.Where(p => p.Type == type && p.Name.Contains(productName)).Skip((page - 1) * pageSize).Take(
                    pageSize).OrderBy(products => products.Id).ToList();
        }
    }
}
