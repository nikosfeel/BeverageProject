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
            vm.Beers = db.Beers.ToList();

            var beers = vm.Beers.Select(beer => new
            {
                beer.Id,
                beer.Name,
                beer.Description,
                beer.PhotoUrl,
                beer.Price,
                Category = new { beer.GetType().Name, beer.Kind }
            }).ToList();
            vm.Wines = db.Wines.ToList();
            var wines = vm.Wines.Select(wine => new
            {
                wine.Id,
                wine.Name,
                wine.Description,
                wine.PhotoUrl,
                wine.Price,
                Category = new { wine.GetType().Name, wine.Kind }
            }).ToList();

            vm.Whiskeys = db.Whiskeys.ToList();
            var whiskeys = vm.Whiskeys.Select(whiskey => new
            {
                whiskey.Id,
                whiskey.Name,
                whiskey.Description,
                whiskey.PhotoUrl,
                whiskey.Price,
                Category = new { whiskey.GetType().Name, whiskey.Kind }
            }).ToList();
            vm.Spirits = db.Spirits.ToList();
            var spirits = vm.Spirits.Select(spirit => new
            {
                spirit.Id,
                spirit.Name,
                spirit.Description,
                spirit.PhotoUrl,
                spirit.Price,
                Category = new { spirit.GetType().Name, spirit.Kind }
            }).ToList();

            return Json(new { beers = beers, wines = wines, whiskeys = whiskeys, spirits = spirits });
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
            IEnumerable<IProduct> firstProd = db.Beers;
            var Products = firstProd.Union(db.Wines).Union(db.Whiskeys).Union(db.Spirits);

            var product = Products.Where(p => p.Id == Convert.ToInt32(id)).First();

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
