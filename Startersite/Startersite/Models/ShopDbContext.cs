using System;
using System.Data.Entity;
using System.Linq;

namespace Startersite
{
    public class ShopDBContext : DbContext
    {
        static ShopDBContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopDBContext>());
        }
        public ShopDBContext()
            : base("name=ShopDBContext")
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Information> OrderInformation { get; set; }

        public virtual DbSet<BasketLine> BasketLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BasketLine>()
            //    .HasOptional<Order>(s => s.Order)
            //    .WithMany(t => t.BasketLine)
            //    .Map(x => x.MapKey("OrderId"));

            modelBuilder.Entity<BasketLine>()
                .HasOptional<Order>(s => s.Order)
                .WithMany(t => t.BasketLine)
                .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Information>()
            //    .HasOptional<Order>(s => s.Order)
            //    .WithOptionalPrincipal(t => t.OrderInformation)
            //    .Map(x => x.MapKey("OrderId"));

            //modelBuilder.Entity<Information>()
            //    .HasOptional<Order>(s => s.Order)
            //    .WithOptionalPrincipal(t => t.OrderInformation)
            //    .WillCascadeOnDelete(true);
        }
    }
}