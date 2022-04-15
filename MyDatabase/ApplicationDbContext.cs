
using Microsoft.AspNet.Identity.EntityFramework;
using MyDatabase.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities.IdentityUsers;
using Entities;
using Entities.Products;
using Entities.Items;
using Entities.Orders;

namespace MyDatabase
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Sindesmos", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MockupDbInitializer());
            Database.Initialize(false);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }

}
