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

        public virtual DbSet<Orders> Orders { get; set; }

        public virtual DbSet<Information> OrderInformation { get; set; }

        public virtual DbSet<BasketLine> BasketLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketLine>()
                .HasOptional<Orders>(s => s.Order)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}