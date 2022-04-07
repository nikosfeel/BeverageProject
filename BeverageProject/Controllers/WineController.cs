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
    public class WineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wine
        public ActionResult Index(string category, string searchWine, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Wine> wines = Filtering(sortOrder);
            //Filtering
            wines = Filter(searchWine, wines);
            //Sorting
            wines = Sorting(sortOrder, wines);

            int pageSize, pageNumber;
            Pagination(pSize, page, out pageSize, out pageNumber);

            if (category is null)
            {
                return View(wines.ToPagedList(pageNumber, pageSize));
            }
            return View(wines.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        private static List<Wine> Sorting(string sortOrder, List<Wine> wines)
        {
            switch (sortOrder)
            {
                case "PriceDesc": wines = wines.OrderByDescending(x => x.Price).ToList(); break;
                case "PriceAsc": wines = wines.OrderBy(x => x.Price).ToList(); break;
                case "NameAsc": wines = wines.OrderBy(x => x.Name).ToList(); break;
                case "NameDesc": wines = wines.OrderByDescending(x => x.Name).ToList(); break;
                default: wines = wines.OrderBy(x => x.Price).ToList(); break;

            }
            return wines;
        }

        private List<Wine> Filtering(string sortOrder)
        {
            var wines = db.Wines.ToList();
            ViewBag.PD = String.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return wines;
        }

        private static void Pagination(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 10;
        }

        private static List<Wine> Filter(string searchWine, List<Wine> wines)
        {
            if (!string.IsNullOrEmpty(searchWine))
            {
                wines = wines.Where(t => t.Name.ToUpper().Contains(searchWine.ToUpper())).ToList();
            }
            return wines;
        }

        public ActionResult IndexCollection(string category, string searchWine, int? page, int? pSize)
        {
            @ViewBag.searchWine = searchWine;
            var wines = db.Wines.ToList();

            if (!string.IsNullOrEmpty(searchWine))
            {
                wines = wines.Where(t => t.Name.ToUpper().Contains(searchWine.ToUpper())).ToList();
            }

            int pageNumber = page ?? 1;
            int pageSize = pSize ?? 12;
            if (category is null)
            {
                return View(wines.ToPagedList(pageNumber, pageSize));
            }
            return View(wines.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        // GET: Wine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // GET: Wine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Wines.Add(wine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wine);
        }

        // GET: Wine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // POST: Wine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wine);
        }

        // GET: Wine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // POST: Wine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wine wine = db.Wines.Find(id);
            db.Wines.Remove(wine);
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