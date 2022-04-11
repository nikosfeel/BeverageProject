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

namespace BeverageProject.Controllers.Api
{
    public class AllProductsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AllProducts
        public IHttpActionResult Get()
        {
            AdminAllProductsViewModel vm = new AdminAllProductsViewModel();
            vm.Products = db.Products.ToList();

            var products = vm.Products.Select(product => new
            {
                product.ProductId,
                product.Name,
                product.Description,
                product.PhotoUrl,
                product.Price,
                product.Kind,
                Category = new { product.Category.GetType().Name}
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/AllProducts/5
        [ResponseType(typeof(IProduct))]
        public IHttpActionResult DeleteProduct(string id)
        {

            var Products = db.Products.ToList();
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
