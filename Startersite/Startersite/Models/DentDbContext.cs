using System;
using System.Data.Entity;
using System.Linq;

namespace Startersite
{
    public class DentDbContext : DbContext
    {
        public DentDbContext()
            : base("name=DentDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Products> Products { get; set; }
    }
}