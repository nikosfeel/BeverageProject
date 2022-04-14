using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PersistenceLayerGeneric.Repositories
{
    public class ProductService : GenericRepository<Product>
    {
        
        public ProductService(ApplicationDbContext context) : base(context)
        {
            
        }
        public IEnumerable<Product> GetAllProductsWithCategory()
        {
            var products = Context.Products.Include(x => x.Category).ToList();
            return products;
        }
    }
}

