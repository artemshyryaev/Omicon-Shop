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
            : base("name=ShopDB")
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Information> OrderInformation { get; set; }

        public virtual DbSet<BasketLine> BasketLines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketLine>()
                .HasOptional<Order>(s => s.Order)
                .WithMany(t => t.BasketLine)
                .WillCascadeOnDelete(true);
        }
    }
}