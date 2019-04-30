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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Order>()
                .HasOptional(s => s.OrderInformation)
                .WithRequired(s => s.Order);

            modelBuilder.Entity<Order>()
                .HasOptional(s => s.User)
                .WithMany(s => s.Orders)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<BasketLine>()
                .HasOptional(s => s.Order)
                .WithMany(s => s.BasketLine)
                .HasForeignKey(s => s.OrderId);

            modelBuilder.Entity<User>()
                .HasOptional(s => s.UserAddress)
                .WithRequired(s => s.User);

            modelBuilder.Entity<User>()
                .HasOptional(s => s.UserPersonalInformation)
                .WithRequired(s => s.User);

            //modelBuilder.Entity<BasketLine>()
            //    .HasOptional<Order>(s => s.Order)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Order>()
            //    .HasRequired(s => s.OrderInformation)
            //    .WithMany()
            //    .HasForeignKey(s => s.OrderInformationId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<OrderInformation>()
            //    .HasRequired(s => s.Order)
            //    .WithMany()
            //    .HasForeignKey(s => s.OrderId);

            //modelBuilder.Entity<User>()
            //    .HasRequired(s => s.UserAddress)
            //    .WithMany()
            //    .HasForeignKey(s => s.UserAddressId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserAddress>()
            //    .HasRequired(s => s.User)
            //    .WithMany()
            //    .HasForeignKey(s => s.UserId);

            //modelBuilder.Entity<User>()
            //    .HasRequired(s => s.UserPersonalInformation)
            //    .WithMany()
            //    .HasForeignKey(s => s.UsersPersonalInformationId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserPersonalInformation>()
            //    .HasRequired(s => s.User)
            //    .WithMany()
            //    .HasForeignKey(s => s.UserId);

            //modelBuilder.Entity<Order>()
            //    .HasRequired(s => s.User)
            //    .WithMany()
            //    .HasForeignKey(s => s.UserId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<BasketLine>()
            //    .HasRequired(s => s.Order)
            //    .WithMany()
            //    .HasForeignKey(s => s.OrderId);

            //modelBuilder.Entity<BasketLine>()
            //    .HasRequired(s => s.Product)
            //    .WithMany()
            //    .HasForeignKey(s => s.ProductId);
        }
    }
}
