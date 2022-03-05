using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var beers = db.Beers.ToList();
            foreach (var beer in beers)
            {
                Console.WriteLine(beer.Name);
            }
        }
    }
}
