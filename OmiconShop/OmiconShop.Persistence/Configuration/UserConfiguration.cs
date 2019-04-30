using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Persistence.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(e => e.UserId);

            Property(e => e.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Email).HasMaxLength(60).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
