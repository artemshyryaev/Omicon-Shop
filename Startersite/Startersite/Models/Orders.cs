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

        public Users UserId { get; set; }

        public string UserName { get; set; }

        public ICollection<Products> Products { get; set; }

        public int ItemCount { get { return Products.Count; } }

        public double OrderTotal {
            get
            {
                double sum = 0;
                foreach (var el in Products)
                {
                    sum += el.Price;
                }

                return sum;
            }
        }

        public DateTime OrderDate { get; set; }

        public Orders()
        {
            Products = new List<Products>();
        }
    }
}
