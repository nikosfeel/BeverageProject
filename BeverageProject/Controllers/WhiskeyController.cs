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
using PagedList;

namespace BeverageProject.Controllers
{
    public class WhiskeyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult SortBy(IEnumerable<Whiskey> whiskeys)
        {
            whiskeys = db.Whiskeys.ToList();

            return null;
        }





        // GET: Whiskey
        public ActionResult Index(string category,string searchWhiskey, int? page, int? pSize)
        {
            @ViewBag.searchWhiskey = searchWhiskey;
            var whiskeys = db.Whiskeys.ToList();
            if (!string.IsNullOrEmpty(searchWhiskey))
            {
                whiskeys = whiskeys.Where(t => t.Name.ToUpper().Contains(searchWhiskey.ToUpper())).ToList();
            }

            int pageNumber = page ?? 1;
            int pageSize = pSize ?? 10;
            if (category is null)
            {
                return View(whiskeys.ToPagedList(pageNumber, pageSize));
            }
            return View(whiskeys.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult IndexCollection(int? page, int? pSize)
        {
            var whiskeys = db.Whiskeys.ToList();

            int pagenumber = page ?? 1;
            int pagesize = pSize ?? 12;
            return View(whiskeys.ToPagedList(pagenumber, pagesize));
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
