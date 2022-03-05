using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class Spirit : GenericRepository<Spirit>
    {
        public Spirit(ApplicationDbContext context) : base(context)
        {
        }
    }
}
