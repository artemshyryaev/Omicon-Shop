using OmiconShop.Application.Basket.Operations;
using OmiconShop.Application.Basket.ViewModel;
using OmiconShop.Application.Checkout.Operations;
using OmiconShop.Application.IRepository;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OmiconShop.Application.Basket
{
    public class BasketApi
    {
        IProductRepository productRepository;
        BasketOperations basketOperations;

        public BasketApi(IProductRepository productRepository, BasketOperations basketOperations)
        {
            this.productRepository = productRepository;
            this.basketOperations = basketOperations;
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

        public BasketViewModel GetCurrentBasket()
        {
            return basketOperations.GetBasket();
        }

        public BasketViewModel GetModifiedBasket(BasketViewModel basket, string id, string uom, string qty)
        {
            var productId = int.Parse(id);
            Enum.TryParse(uom, out UOM productUOM);
            var productQty = double.Parse(qty);

            basket.ModifyLineQty(productId, productUOM, productQty);

            return basket;
        }
    }
}
