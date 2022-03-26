using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using PersistenceLayerGeneric.Repositories;
using Entities.Products;
using Entities;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var beers = db.Beers;
            var spirits = db.Spirits;
            var whiskeys = db.Whiskeys;
            var wines = db.Wines;


            IEnumerable<IProduct> firstProd = db.Beers;
            var Products = firstProd.Union(db.Wines).Union(db.Whiskeys).Union(db.Spirits);

            foreach (var item in Products)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
          
        }
    }
}
