using OmiconShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OmiconShop.Persistence
{
    public class ShopDBContext : DbContext
    {
        static ShopDBContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopDBContext>());
        }
        public ShopDBContext()
            : base("name=ShopDB")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BasketLine> BasketLines { get; set; }

        public virtual DbSet<OrderInformation> OrderInformation { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<UserAddress> UsersAddresses { get; set; }

        public virtual DbSet<UserPersonalInformation> UsersPersonalInformation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            modelBuilder.Conventions.Add<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add<OneToOneConstraintIntroductionConvention>();
        }
    }
}
