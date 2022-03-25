using Entities;
using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeverageProject.Models
{
    public class ItemModel
    {
        private ApplicationDbContext db;
        private IEnumerable<IProduct> Products;
        

        public ItemModel()
        {
            db = new ApplicationDbContext();
            var beers = db.Beers;
            var spirits = db.Spirits;
            var whiskeys = db.Whiskeys;
            var wines = db.Wines;


            IEnumerable<IProduct> prod = beers;
            var allProducts = prod.Union(spirits).Union(whiskeys).Union(wines);
            Products = allProducts;
            
        }

        public IEnumerable<IProduct> findAllProducts()
        {
            return this.Products;
        }
               
        public IProduct FindProduct(int? id)
        {
            return this.Products.Single(p => p.Id.Equals(id));
        }
    }
}
