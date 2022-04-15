using BeverageProject.Models.ViewModels;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Http.Description;
using Entities;
using Entities.Products;
using System.Data.Entity.Infrastructure;
using PersistenceLayerGeneric.Repositories;

namespace BeverageProject.Controllers.Api
{
    public class AllProductsController : ApiController
    {
        private ApplicationDbContext db;
        private ProductService prodService;
        public AllProductsController()
        {
            db = new ApplicationDbContext();
            prodService = new ProductService(db);
        }

        // GET: api/AllProducts
        public IHttpActionResult Get()
        {
            AdminAllProductsViewModel vm = new AdminAllProductsViewModel();
            vm.Products = prodService.GetAllProductsWithCategory();

            var products = vm.Products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Description,
                product.PhotoUrl,
                product.Price,
                product.Kind,
                Category = product.Category.Title,
            }).ToList();


            return Json(new { products = products });
        }

        // GET: api/AllProducts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AllProducts
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AllProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Product product)
        {
            
            var prod = prodService.Get(id);
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Price = product.Price;

            db.Entry(prod).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);

        }

        private bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/AllProducts/5
        [ResponseType(typeof(IProduct))]
        public IHttpActionResult DeleteProduct(string id)
        {

            var Products = prodService.GetAll();
            var product = Products.Where(p => p.ProductId == Convert.ToInt32(id)).First();

            if (product == null)
            {
                return NotFound();
            }

            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
