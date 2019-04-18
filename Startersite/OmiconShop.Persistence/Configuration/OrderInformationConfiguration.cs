using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Persistence.Configuration
{
    public class OrderInformationConfiguration : EntityTypeConfiguration<OrderInformation>
    {
        public OrderInformationConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Total).IsRequired();
            Property(e => e.Date).HasColumnType("datetime").IsRequired();
            Property(e => e.Delivery).IsRequired();
            Property(e => e.Payment).IsRequired();
        }
    }
}
