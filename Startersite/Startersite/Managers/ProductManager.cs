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
        IProductRepository productsRepo;

        public ProductManager(IProductRepository productsRepo)
        {
            this.productsRepo = productsRepo;
        }

        public IEnumerable<Product> GetProducts(int page, int pageSize, string type = null)
        {
            if (type == null)
                return productsRepo.Products.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                     products => products.Id);
            else
                return productsRepo.Products.Where(p => p.Type == type).Skip((page - 1) * pageSize).Take(pageSize).OrderBy(
                    products => products.Id);
        }

        public static Product CreateProductModelFromProductViewModel(ProductViewModel productView, int id = 0)
        {
            Product product = new Product();

            if (productView != null)
            {
                product.Name = productView.Name;
                product.Description = productView.Description;
                product.Price = productView.Price;
                product.Type = productView.Type;
                //product.ImageData = productView.ImageData;
                //product.ImageMimeType = productView.ImageMimeType;

                if (id != 0)
                    product.Id = id;
            }

            return product;
        }

        public static ProductViewModel CreateProductViewModelFromProductModel(Product productModel)
        {
            ProductViewModel product = new ProductViewModel();

            if (productModel != null)
            {
                product.Name = productModel.Name;
                product.Description = productModel.Description;
                product.Price = productModel.Price;
                product.Type = productModel.Type;
                //product.ImageData = productModel.ImageData;
                //product.ImageMimeType = productModel.ImageMimeType;
            }

            return product;
        }

        public static ProductViewModel AddImageDataToProduct(ProductViewModel productViewModel, HttpPostedFileBase image)
        {
            if (productViewModel != null && image != null)
            {
                //productViewModel.ImageData = new byte[image.ContentLength];
                //productViewModel.ImageMimeType = image.ContentType;
            }

            return productViewModel;
        }
    }
}