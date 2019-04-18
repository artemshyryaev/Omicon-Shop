using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmiconShop.Persistence.Configuration
{
    public class UserPersonalInformationConfiguration : EntityTypeConfiguration<UserPersonalInformation>
    {
        public UserPersonalInformationConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Name).HasMaxLength(60).HasColumnType("ntext").IsRequired();
            Property(e => e.Surname).HasMaxLength(80).HasColumnType("ntext").IsRequired();
            Property(e => e.PhoneNumber).HasMaxLength(24).HasColumnType("ntext").IsRequired();
            //Property(e => e.Email).HasMaxLength(60).HasColumnType("ntext").IsRequired();
        }
    }
}
