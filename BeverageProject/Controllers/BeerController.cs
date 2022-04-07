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
    public class BeerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beer
        public ActionResult Index(string category, string searchBeer, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Beer> beers = Filtering(sortOrder);
            //Filtering
            beers = Filter(searchBeer, beers);
            //Sorting
            beers = Sorting(sortOrder, beers);

            int pageSize, pageNumber;
            Pagination(pSize, page, out pageSize, out pageNumber);

            if (category is null)
            {
                return View(beers.ToPagedList(pageNumber, pageSize));
            }
            return View(beers.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));

        }

        private static List<Beer> Sorting(string sortOrder, List<Beer> beers)
        {
            switch (sortOrder)
            {
                case "PriceDesc": beers = beers.OrderByDescending(x => x.Price).ToList(); break;
                case "PriceAsc": beers = beers.OrderBy(x => x.Price).ToList(); break;
                case "NameAsc": beers = beers.OrderBy(x => x.Name).ToList(); break;
                case "NameDesc": beers = beers.OrderByDescending(x => x.Name).ToList(); break;
                default: beers = beers.OrderBy(x => x.Price).ToList(); break;

            }
            return beers;
        }

        private List<Beer> Filtering(string sortOrder)
        {
            var beers = db.Beers.ToList();
            ViewBag.PD = String.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return beers;
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

        private static List<Beer> Filter(string searchBeer, List<Beer> beers)
        {
            if (!string.IsNullOrEmpty(searchBeer))
            {
                beers = beers.Where(t => t.Name.ToUpper().Contains(searchBeer.ToUpper())).ToList();
            }
            return beers;
        }

        public ActionResult IndexCollection(string category, string searchBeer, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Beer> beers = Filtering(sortOrder);
            //Filtering
            beers = Filter(searchBeer, beers);
            //Sorting
            beers = Sorting(sortOrder, beers);

            int pageSize, pageNumber;
            PaginationSecondView(pSize, page, out pageSize, out pageNumber);
            if (category is null)
            {
                return View(beers.ToPagedList(pageNumber, pageSize));
            }
            return View(beers.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        // GET: Beer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // GET: Beer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beer);
        }

        // GET: Beer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beer);
        }

        // GET: Beer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beer beer = db.Beers.Find(id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            return View(beer);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beer beer = db.Beers.Find(id);
            db.Beers.Remove(beer);
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
