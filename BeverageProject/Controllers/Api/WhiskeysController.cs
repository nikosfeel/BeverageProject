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
    public class WhiskeysController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Whiskeys
        public IHttpActionResult GetWhiskeys()
        {
            var Whiskeys = db.Whiskeys.Select(Whiskey => new
            {
                Whiskey.Id,
                Whiskey.Name,
                Whiskey.Description,
                Whiskey.PhotoUrl,
                Whiskey.Price,
                Category = new { Whiskey.Category.Title, Whiskey.Category.Kind }
            }).ToList();


            return Json(new { whiskeys = Whiskeys });
        }

        // GET: api/Whiskeys/5
        [ResponseType(typeof(Whiskey))]
        public IHttpActionResult GetWhiskey(int id)
        {
            Whiskey whiskey = db.Whiskeys.Find(id);
            if (whiskey == null)
            {
                return NotFound();
            }

            return Ok(whiskey);
        }

        // PUT: api/Whiskeys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWhiskey(int id, Whiskey whiskey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != whiskey.Id)
            {
                return BadRequest();
            }

            db.Entry(whiskey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhiskeyExists(id))
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

        // POST: api/Whiskeys
        [ResponseType(typeof(Whiskey))]
        public IHttpActionResult PostWhiskey(Whiskey whiskey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Whiskeys.Add(whiskey);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = whiskey.Id }, whiskey);
        }

        // DELETE: api/Whiskeys/5
        [ResponseType(typeof(Whiskey))]
        public IHttpActionResult DeleteWhiskey(int id)
        {
            Whiskey whiskey = db.Whiskeys.Find(id);
            if (whiskey == null)
            {
                return NotFound();
            }

            db.Whiskeys.Remove(whiskey);
            db.SaveChanges();

            return Ok(whiskey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WhiskeyExists(int id)
        {
            return db.Whiskeys.Count(e => e.Id == id) > 0;
        }
    }
}