using OmiconShop.Application.Admin.ViewModel;
using OmiconShop.Application.Home.Operations;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using OmiconShop.SentimentAnalysis;
using System.Linq;

namespace OmiconShop.Application.Home
{
    public class HomeApi
    {
        IProductRepository productRepository;
        ProductOperations productOperations;

        public HomeApi(IProductRepository productRepository, ProductOperations productOperations)
        {
            this.productRepository = productRepository;
            this.productOperations = productOperations;
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        public ProductsListViewModel GetProductsListViewModel(string type, string productName, int page, int pageSize)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productOperations.GetProducts(page, pageSize, type, productName),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    TotalItems = type == null
                    ? productRepository.GetAllProducts().Count()
                    : productRepository.GetAllProducts().Where(p => p.Type == type).Count(),
                    ItemsPerPage = pageSize
                },
                Type = type
            };

            return model;
        }

        public int GetProductAverageProbability(int productId)
        {
            var comments = new CommentsSentimentAnalysis(productId);

            return comments.GetAverageProbability();
        }

        public int GetProductAverageProbability(int productId, string sentiment)
        {
            var comments = new CommentsSentimentAnalysis(productId);

            return comments.UpdateDataAndGetAverageProbability(sentiment);
        }
    }
}
