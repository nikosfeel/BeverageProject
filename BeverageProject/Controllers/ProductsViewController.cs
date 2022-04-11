using Entities.Products;
using MyDatabase;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers
{
    public class ProductsViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beer
        public ActionResult Index(string category, string kind, string searchProduct, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            List<Product> products = Filtering(sortOrder);
            //Filtering
            products = Filter(searchProduct, products);
            //Sorting
            products = Sorting(sortOrder, products);

            int pageSize, pageNumber;
            Pagination(pSize, page, out pageSize, out pageNumber);

            if (kind is null)
            {
                return View(products.Where(x => x.Category.Title == category).ToPagedList(pageNumber, pageSize));
            }

            return View(products.Where(x => x.Category.Title == category && x.Kind == kind).ToPagedList(pageNumber, pageSize));

        }

        private static List<Product> Sorting(string sortOrder, List<Product> products)
        {
            switch (sortOrder)
            {
                case "PriceDesc": products = products.OrderByDescending(x => x.Price).ToList(); break;
                case "PriceAsc": products = products.OrderBy(x => x.Price).ToList(); break;
                case "NameAsc": products = products.OrderBy(x => x.Name).ToList(); break;
                case "NameDesc": products = products.OrderByDescending(x => x.Name).ToList(); break;
                default: products = products.OrderBy(x => x.Price).ToList(); break;

            }
            return products;
        }

        private List<Product> Filtering(string sortOrder)
        {
            var products = db.Products.ToList();
            ViewBag.PD = String.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return products;
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

        private static List<Product> Filter(string searchBeer, List<Product> beers)
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
            List<Product> beers = Filtering(sortOrder);
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
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Beer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Beer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Beer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Beer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
