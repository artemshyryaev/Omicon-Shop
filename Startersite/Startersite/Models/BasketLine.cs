using Startersite.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Startersite.Models
{
    public class BasketLine
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public double Qty { get; set; }

        public UOM Uom { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}