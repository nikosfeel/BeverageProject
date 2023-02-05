using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;


namespace PersistenceLayerGeneric.Repositories
{
    public class ProductService : GenericRepository<Product>
    {
        
        public ProductService(ApplicationDbContext context) : base(context)
        {
            
        }
        public IEnumerable<Product> GetAllProductsWithCategory()
        {
            var products = Context.Products.Include(x => x.Category).ToList();
            return products;
        }

        public Product Edit(Product product)
        {
            var prod = base.Get(product.ProductId);
            if (prod == null)
                return null;

            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;

            Context.Entry(prod).State = EntityState.Modified;
            Context.SaveChanges();
            return prod;
        }

        public Product Delete(int id)
        {
            var product = Context.Products.Find(id);

            if (product == null)
                return null;

            Context.Products.Remove(product);
            Context.SaveChanges();

            return product;
        }
    }
}

