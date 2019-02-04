using Startersite.Models.ModelViews;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Startersite
{
    public class BasketLine
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Qty { get; set; }

        public Orders Order { get; set; }
    }
}