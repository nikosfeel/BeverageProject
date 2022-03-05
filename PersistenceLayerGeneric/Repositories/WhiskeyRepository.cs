using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class WhiskeyRepository : GenericRepository<Whiskey>
    {
        public WhiskeyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
