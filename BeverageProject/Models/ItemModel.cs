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
        private IEnumerable<Product> Products;

        public ItemModel()
        {
            db = new ApplicationDbContext();
            var products = db.Products.ToList();

            Products = products;
        }

        public IEnumerable<Product> FindAllProducts()
        {
            return this.Products;
        }

        public Product FindProduct(int? id)
        {
            return this.Products.Single(p => p.ProductId.Equals(id));
        }
    }
}
