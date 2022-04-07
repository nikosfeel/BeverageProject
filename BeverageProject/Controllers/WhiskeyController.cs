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

        // GET: Whiskey
        public ActionResult Index(string category, string searchWhiskey, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Whiskey> whiskeys = Filtering(sortOrder);
            //Filtering
            whiskeys = Filter(searchWhiskey, whiskeys);
            //Sorting
            whiskeys = Sorting(sortOrder, whiskeys);

            int pageSize, pageNumber;
            Pagination(pSize, page, out pageSize, out pageNumber);

            if (category is null)
            {
                return View(whiskeys.ToPagedList(pageNumber, pageSize));
            }
            return View(whiskeys.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        private static List<Whiskey> Sorting(string sortOrder, List<Whiskey> whiskeys)
        {
            switch (sortOrder)
            {
                case "PriceDesc": whiskeys = whiskeys.OrderByDescending(x => x.Price).ToList(); break;
                case "PriceAsc": whiskeys = whiskeys.OrderBy(x => x.Price).ToList(); break;
                case "NameAsc": whiskeys = whiskeys.OrderBy(x => x.Name).ToList(); break;
                case "NameDesc": whiskeys = whiskeys.OrderByDescending(x => x.Name).ToList(); break;
                default: whiskeys = whiskeys.OrderBy(x => x.Price).ToList(); break;

            }
            return whiskeys;
        }

        private List<Whiskey> Filtering(string sortOrder)
        {
            var whiskeys = db.Whiskeys.ToList();
            ViewBag.PD = String.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return whiskeys;
        }

        private static void Pagination(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 10;
        }

        private static void PaginationSecondView(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 12;
        }

        private static List<Whiskey> Filter(string searchWhiskey, List<Whiskey> whiskeys)
        {
            if (!string.IsNullOrEmpty(searchWhiskey))
            {
                whiskeys = whiskeys.Where(t => t.Name.ToUpper().Contains(searchWhiskey.ToUpper())).ToList();
            }
            return whiskeys;
        }

        public ActionResult IndexCollection(string category, string searchWhiskey, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Whiskey> whiskeys = Filtering(sortOrder);
            //Filtering
            whiskeys = Filter(searchWhiskey, whiskeys);
            //Sorting
            whiskeys = Sorting(sortOrder, whiskeys);

            int pageSize, pageNumber;
            PaginationSecondView(pSize, page, out pageSize, out pageNumber);
            if (category is null)
            {
                return View(whiskeys.ToPagedList(pageNumber, pageSize));
            }
            return View(whiskeys.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
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
