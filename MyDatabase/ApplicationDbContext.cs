
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
using Entities.Categories;

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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Whiskey> Whiskeys { get; set; }
        public DbSet<Spirit> Spirits { get; set; }
        public DbSet<BeerCategory> BeerCategories { get; set; }
        public DbSet<WineCategory> WineCategories { get; set; }
        public DbSet<WhiskeyCategory> WhiskeyCategories { get; set; }
        public DbSet<SpiritCategory> SpiritCategories { get; set; }



    }

}
