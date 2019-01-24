using System;
using System.Data.Entity;
using System.Linq;

namespace Startersite
{
    public class DentDbContext : DbContext
    {
        static DentDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DentDbContext>());
        }
        public DentDbContext()
            : base("name=DentDbContext")
        {
        }

        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Orders> Orders { get; set; }
    }
}