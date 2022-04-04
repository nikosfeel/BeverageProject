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
            var products = db.Products.ToList();


            foreach (var item in products)
            {
                Console.WriteLine(item.GetType().Name);
            }          
        }
    }
}
