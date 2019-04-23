using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Persistence.Configuration
{
    public class BasketLineConfiguration : EntityTypeConfiguration<BasketLine>
    {
        public BasketLineConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Qty).IsRequired();
            Property(e => e.Uom).IsRequired();
        }
    }
}
