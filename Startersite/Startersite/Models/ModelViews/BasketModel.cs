using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ModelViews
{
    public class BasketModel
    {
        public List<BasketLineModel> lineCollection = new List<BasketLineModel>();

        public IEnumerable<BasketLineModel> Lines { get { return lineCollection; } }

        public void Add(Products product, double quantity)
        {
            var isProductInBasket = lineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (isProductInBasket == null)
            {
                lineCollection.Add(new BasketLineModel { Product = product, Quantity = quantity });
            }
            else
            {
                isProductInBasket.Quantity += quantity;
            }
        }

        public void RemoveLine(Products product)
        {
            lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public void ClearBasket()
        {
            lineCollection.Clear();
        }

        public double BasketTotal()
        {
            return lineCollection.Sum(p => p.Product.ProductId * p.Quantity);
        }
    }

    public class BasketLineModel
    {
        public Products Product { get; set; }

        public double Quantity { get; set; }
    }
}