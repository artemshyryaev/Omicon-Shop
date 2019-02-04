using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace Startersite
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string CustomerEmail { get; set; }

        public Information OrderInformation { get; set; }

        public ICollection<BasketLine> BasketLine { get; set; }

        public double OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }

        public Orders()
        {
            BasketLine = new List<BasketLine>();
        }
    }
}
