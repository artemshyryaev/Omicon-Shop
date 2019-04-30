using System;
using OmiconShop.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OmiconShop.Persistence.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(e => e.ProductId);

            Property(e => e.ProductId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).IsRequired().HasMaxLength(40).HasColumnType("nvarchar(max)");
            Property(e => e.Description).HasMaxLength(250).HasColumnType("nvarchar(max)");
            Property(e => e.Price).IsRequired().HasColumnType("money");
            Property(e => e.Type).IsRequired().HasMaxLength(40).HasColumnType("nvarchar(max)");
            Property(e => e.ImageUrl).HasColumnType("nvarchar(max)");
        }
    }
}
