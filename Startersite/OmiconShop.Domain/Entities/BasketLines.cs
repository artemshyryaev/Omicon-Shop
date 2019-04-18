using System;
using OmiconShop.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace OmiconShop.Domain.Entities
{
    public class BasketLine
    {
        public int Id { get; set; }

        public double Qty { get; set; }

        public UOM Uom { get; set; }

        public int? ProductId { get; set; }

        public Product Product { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}