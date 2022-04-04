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

            //foreach (var item in orders)
            //{
            //    Console.WriteLine(item.FullName);
            //}

           
            List<Beer> beers = db.Beers.ToList();
            SortedDescendingByPrice(beers);
            PrintArray(beers, "sorted Array");

        }

        private static void PrintArray(List<Beer> beers, string message)
        {
            Console.WriteLine(message);
            foreach (Beer beer in beers)
            {
                Console.WriteLine($"{beer.Name,-45}{beer.Price,-15}");
            }
        }



        private static void SortedDescendingByPrice(List<Beer> beers)
        {
            Beer t;
            int size = beers.Count - 2;
            for (int p = 0; p <= size; p++)
            {
                for (int i = 0; i <= size; i++)
                {
                    if (beers[i].Price < beers[i + 1].Price)
                    {
                        t = beers[i + 1];
                        beers[i + 1] = beers[i];
                        beers[i] = t;
                    }
                }
            }
        }

        private static void SortedAscendingByPrice(List<Beer> beers)
        {
            Beer t;
            int size = beers.Count - 2;
            for (int p = 0; p <= size; p++)
            {
                for (int i = 0; i <= size; i++)
                {
                    if (beers[i].Price > beers[i + 1].Price)
                    {
                        t = beers[i + 1];
                        beers[i + 1] = beers[i];
                        beers[i] = t;
                    }
                }
            }
        }

    }
}
