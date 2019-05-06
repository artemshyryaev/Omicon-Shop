using System;
using System.Collections.Generic;
using OmiconShop.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmiconShop.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public OrderStatuses Status { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public int? OrderInformationId { get; set; }

        public virtual OrderInformation OrderInformation { get; set; }

        public virtual ICollection<BasketLine> BasketLine { get; private set; }

        public Order()
        {
            BasketLine = new HashSet<BasketLine>();
        }
    }
}
