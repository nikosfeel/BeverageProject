using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayerGeneric.Repositories
{
    public class CategoryService : GenericRepository<Category>
    {
        public CategoryService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
