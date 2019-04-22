using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Application.Basket
{
    public class BasketApi
    {
        IProductRepository productRepository;

        public BasketApi(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddToCart(BasketViewModel basket, int productId, double quantity, UOM uom)
        {
            var product = productRepository.GetProductById(productId);

            if (product != null)
                basket.Add(product, quantity, uom);
        }

        public void RemoveFromBasket(BasketViewModel basket, int productId, UOM uom)
        {
            var product = productRepository.GetProductById(productId);

            if (product != null)
                basket.RemoveLine(product, uom);
        }

        public void EmptyBasket(BasketViewModel basket)
        {
            var product = productRepository.GetAllProducts().Count();

            if (product >= 1)
                basket.ClearBasket();
        }
    }
}
