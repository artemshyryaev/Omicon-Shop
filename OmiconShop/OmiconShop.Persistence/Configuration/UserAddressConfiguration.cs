using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Persistence.Configuration
{
    public class UserAddressConfiguration : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Country).HasMaxLength(60).HasColumnType("nvarchar(max)").IsRequired();
            Property(e => e.City).HasMaxLength(60).HasColumnType("nvarchar(max)").IsRequired();
            Property(e => e.Address).HasMaxLength(100).HasColumnType("nvarchar(max)").IsRequired();
            Property(e => e.ZipCode).HasMaxLength(10).IsRequired();
        }
    }
}
