using Startersite.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace Startersite.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public OrderStatuses Status { get; set; }

        public double Total { get; set; }

        public string CustomerEmail { get; set; }

        public DateTime Date { get; set; }

        public int? OrderInformationId { get; set; }

        public Information OrderInformation { get; set; }

        public ICollection<BasketLine> BasketLine { get; set; }

        public int? UserId { get; set; }

        public Users User { get; set; }

        public Order()
        {
            BasketLine = new List<BasketLine>();
        }
    }
}
