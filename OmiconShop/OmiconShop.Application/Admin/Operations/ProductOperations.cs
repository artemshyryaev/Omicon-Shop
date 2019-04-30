using OmiconShop.Application.Admin.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Admin.Operations
{
    public class ProductOperations
    {
        IProductRepository productRepository;

        public ProductOperations(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize, string productName = null)
        {
            var allProducts = productRepository.GetAllProducts();

            if (string.IsNullOrEmpty(productName))
                return allProducts.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                     products => products.ProductId).ToList();
            else
                return allProducts.Where(p => p.Name.Contains(productName)).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.ProductId).ToList();
        }

        public void AddImagePathToProduct(ref ProductViewModel productViewModel, string path)
        {
            if (productViewModel != null && path != null)
            {
                productViewModel.ImageUrl = path;
            }
        }

        public Product CreateProductModelFromProductViewModel(ProductViewModel productView, int id = 0)
        {
            Product product = new Product();

            if (productView != null)
            {
                product.Name = productView.Name;
                product.Description = productView.Description;
                product.Price = productView.Price;
                product.Type = productView.Type;
                product.ImageUrl = productView.ImageUrl;

                if (id != 0)
                    product.ProductId = id;
            }

            return product;
        }

        public ProductViewModel CreateProductViewModelFromProductModel(Product productModel)
        {
            ProductViewModel product = new ProductViewModel();

            if (productModel != null)
            {
                product.Name = productModel.Name;
                product.Description = productModel.Description;
                product.Price = productModel.Price;
                product.Type = productModel.Type;
                product.ImageUrl = productModel.ImageUrl;
            }

            return product;
        }
    }
}
