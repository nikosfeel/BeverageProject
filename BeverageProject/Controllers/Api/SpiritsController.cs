using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Entities.Products;
using MyDatabase;

namespace BeverageProject.Controllers.Api
{
    public class SpiritsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Spirits
        public IHttpActionResult GetSpirits()
        {
            var spirits = db.Spirits.Select(spirit => new
            {
                spirit.Id,
                spirit.Name,
                spirit.Description,
                spirit.PhotoUrl,
                spirit.Price,
                Category = new { spirit.Name, spirit.Kind }
            }).ToList();

            return Json(new { spirits = spirits });
        }

        // GET: api/Spirits/5
        [ResponseType(typeof(Spirit))]
        public IHttpActionResult GetSpirit(int id)
        {
            Spirit spirit = db.Spirits.Find(id);
            if (spirit == null)
            {
                return NotFound();
            }
            return Ok(spirit);
        }

        // PUT: api/Spirits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpirit(int id, Spirit spirit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spirit.Id)
            {
                return BadRequest();
            }

            db.Entry(spirit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpiritExists(id))
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

        // POST: api/Spirits
        [ResponseType(typeof(Spirit))]
        public IHttpActionResult PostSpirit(Spirit spirit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Spirits.Add(spirit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spirit.Id }, spirit);
        }

        // DELETE: api/Spirits/5
        [ResponseType(typeof(Spirit))]
        public IHttpActionResult DeleteSpirit(int id)
        {
            Spirit spirit = db.Spirits.Find(id);
            if (spirit == null)
            {
                return NotFound();
            }

            db.Spirits.Remove(spirit);
            db.SaveChanges();

            return Ok(spirit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpiritExists(int id)
        {
            return db.Spirits.Count(e => e.Id == id) > 0;
        }
    }
}