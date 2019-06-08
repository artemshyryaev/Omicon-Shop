using OmiconShop.Application.Admin.ViewModel;
using OmiconShop.Application.Home.Operations;
using OmiconShop.Application.Home.ViewModels;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ProductDetailsViewModel GetProductById(int id)
        {
            var viewModel = new ProductDetailsViewModel
            {
                Product = productRepository.GetProductById(id)
            };

            return viewModel;
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
    }
}
