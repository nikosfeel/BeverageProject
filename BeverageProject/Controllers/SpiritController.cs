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
    public class SpiritController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Spirit
        public ActionResult Index(string category, string searchSpirit, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Spirit> spirits = Filtering(sortOrder);
            //Filtering
            spirits = Filter(searchSpirit, spirits);
            //Sorting
            spirits = Sorting(sortOrder, spirits);

            int pageSize, pageNumber;
            Pagination(pSize, page, out pageSize, out pageNumber);

            if (category is null)
            {
                return View(spirits.ToPagedList(pageNumber, pageSize));
            }
            return View(spirits.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        private static List<Spirit> Sorting(string sortOrder, List<Spirit> spirits)
        {
            switch (sortOrder)
            {
                case "PriceDesc": spirits = spirits.OrderByDescending(x => x.Price).ToList(); break;
                case "PriceAsc": spirits = spirits.OrderBy(x => x.Price).ToList(); break;
                case "NameAsc": spirits = spirits.OrderBy(x => x.Name).ToList(); break;
                case "NameDesc": spirits = spirits.OrderByDescending(x => x.Name).ToList(); break;
                default: spirits = spirits.OrderBy(x => x.Price).ToList(); break;

            }
            return spirits;
        }

        private List<Spirit> Filtering(string sortOrder)
        {
            var spirits = db.Spirits.ToList();
            ViewBag.PD = String.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return spirits;
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

        private static List<Spirit> Filter(string searchSpirit, List<Spirit> spirits)
        {
            if (!string.IsNullOrEmpty(searchSpirit))
            {
                spirits = spirits.Where(t => t.Name.ToUpper().Contains(searchSpirit.ToUpper())).ToList();
            }
            return spirits;
        }

        public ActionResult IndexCollection(string category, string searchSpirit, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Spirit> spirits = Filtering(sortOrder);
            //Filtering
            spirits = Filter(searchSpirit, spirits);
            //Sorting
            spirits = Sorting(sortOrder, spirits);

            int pageSize, pageNumber;
            PaginationSecondView(pSize, page, out pageSize, out pageNumber);
            if (category is null)
            {
                return View(spirits.ToPagedList(pageNumber, pageSize));
            }
            return View(spirits.Where(x => x.Kind == category).ToPagedList(pageNumber, pageSize));
        }

        // GET: Spirit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spirit spirit = db.Spirits.Find(id);
            if (spirit == null)
            {
                return HttpNotFound();
            }
            return View(spirit);
        }

        // GET: Spirit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spirit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Spirit spirit)
        {
            if (ModelState.IsValid)
            {
                db.Spirits.Add(spirit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spirit);
        }

        // GET: Spirit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spirit spirit = db.Spirits.Find(id);
            if (spirit == null)
            {
                return HttpNotFound();
            }
            return View(spirit);
        }

        // POST: Spirit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Spirit spirit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spirit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spirit);
        }

        // GET: Spirit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spirit spirit = db.Spirits.Find(id);
            if (spirit == null)
            {
                return HttpNotFound();
            }
            return View(spirit);
        }

        // POST: Spirit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spirit spirit = db.Spirits.Find(id);
            db.Spirits.Remove(spirit);
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
