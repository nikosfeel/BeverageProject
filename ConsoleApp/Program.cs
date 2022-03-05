using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceLayerGeneric.Repositories;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            BeerService service = new BeerService(db);

            var beers = service.GetAll();
            foreach (var beer in beers)
            {
                Console.WriteLine(beer.Name);
            }
        }
    }
}
