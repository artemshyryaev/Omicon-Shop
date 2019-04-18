using OmiconShop.Domain.Entities;
using OmiconShop.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Startersite.Models.ViewModel
{
    public class BasketViewModel
    {
        public List<BasketLineModel> lineCollection = new List<BasketLineModel>();

        public IEnumerable<BasketLineModel> Lines { get { return lineCollection; } }

        public void Add(Product product, double quantity, UOM uom)
        {
            var isProductInBasket = lineCollection.Where(p => p.Product.Id == product.Id && p.Uom == uom).FirstOrDefault();

            if (isProductInBasket == null)
            {
                lineCollection.Add(new BasketLineModel { Product = product, Quantity = quantity, Uom = uom });
            }
            else
            {
                isProductInBasket.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product, UOM uom)
        {
            lineCollection.RemoveAll(p => p.Product.Id == product.Id && p.Uom == uom);
        }

        public void ClearBasket()
        {
            lineCollection.Clear();
        }

        public double BasketTotal()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }
    }

    public class BasketLineModel
    {
        public Product Product { get; set; }

        public double Quantity { get; set; }

        public UOM Uom { get; set; }
    }
}