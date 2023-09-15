using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Client
{
    public class AppContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<Favorite> favorites { get; set; }
        public DbSet<CLient> clients { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Review> reviews { get; set; }
        public AppContext() : base("DefaultConnection") { }
        
    }
}
