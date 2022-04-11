using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class ProductService : GenericRepository<Product>
    {
        public ProductService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
