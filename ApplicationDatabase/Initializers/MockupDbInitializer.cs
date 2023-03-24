using ApplicationDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDatabase.Initializers
{
    public class MockupDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            SeedingService service = new SeedingService(context);
            
            service.Seeding();

            base.Seed(context);
        }
    }
}
