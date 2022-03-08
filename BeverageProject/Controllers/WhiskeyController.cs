using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Products;
using MyDatabase;

namespace BeverageProject.Controllers
{
    public class WhiskeyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Whiskey
        public ActionResult Index(string category)
        {
            var whiskeys = db.Whiskeys.Where(x => x.Category.Kind == category).ToList();
            return View(whiskeys);
        }

        // GET: Whiskey/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whiskey whiskey = db.Whiskeys.Find(id);
            if (whiskey == null)
            {
                return HttpNotFound();
            }
            return View(whiskey);
        }

        // GET: Whiskey/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Whiskey/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Whiskey whiskey)
        {
            if (ModelState.IsValid)
            {
                db.Whiskeys.Add(whiskey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(whiskey);
        }

        // GET: Whiskey/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whiskey whiskey = db.Whiskeys.Find(id);
            if (whiskey == null)
            {
                return HttpNotFound();
            }
            return View(whiskey);
        }

        // POST: Whiskey/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Whiskey whiskey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whiskey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whiskey);
        }

        // GET: Whiskey/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whiskey whiskey = db.Whiskeys.Find(id);
            if (whiskey == null)
            {
                return HttpNotFound();
            }
            return View(whiskey);
        }

        // POST: Whiskey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Whiskey whiskey = db.Whiskeys.Find(id);
            db.Whiskeys.Remove(whiskey);
            db.SaveChanges();
            return RedirectToAction("Index");
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
