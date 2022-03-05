using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class BeerService : GenericRepository<Beer>
    {
        public BeerService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
