using BeverageProject.Controllers.HelperMethods;
using Entities.Products;
using MyDatabase;
using PagedList;
using PersistenceLayerGeneric.Repositories;
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
        private ApplicationDbContext db;
        private PaginationAndSorting helper;
        private ProductService prodService;
        

        public ProductsViewController()
        {
            db = new ApplicationDbContext();
            helper = new PaginationAndSorting();
            prodService = new ProductService(db);
            
        }

        // GET: Product
        public ActionResult Index(string category, string kind, string searchProduct, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            ViewBag.Kind = kind;
            List<Product> products = Filtering(sortOrder);
            //Filtering
            products = helper.Filter(searchProduct, products);
            //Sorting
            products = helper.Sorting(sortOrder, products);

            int pageSize, pageNumber;
            helper.Pagination(pSize, page, out pageSize, out pageNumber);

            if (kind is null)
            {
                return View(products.Where(x => x.Category.Title == category).ToPagedList(pageNumber, pageSize));
            }

            return View(products.Where(x => x.Category.Title == category && x.Kind == kind).ToPagedList(pageNumber, pageSize));

        }

        private List<Product> Filtering(string sortOrder)
        {
            var products = db.Products.Include(x => x.Category).ToList();
            ViewBag.PD = string.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return products;
        }

        public ActionResult IndexCollection(string category, string kind, string searchProduct, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            ViewBag.Kind = kind;
            List<Product> products = Filtering(sortOrder);
            //Filtering
            products = helper.Filter(searchProduct, products);
            //Sorting
            products = helper.Sorting(sortOrder, products);

            int pageSize, pageNumber;
            helper.PaginationSecondView(pSize, page, out pageSize, out pageNumber);

            if (kind is null)
            {
                return View(products.Where(x => x.Category.Title == category).ToPagedList(pageNumber, pageSize));
            }

            return View(products.Where(x => x.Category.Title == category && x.Kind == kind).ToPagedList(pageNumber, pageSize));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = prodService.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                prodService.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = prodService.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = prodService.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prodService.Remove(id);            
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
