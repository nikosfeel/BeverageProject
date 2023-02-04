using BeverageProject.Helpers;
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
    public class ClientProductsController : Controller
    {
        private ApplicationDbContext db;
        private PaginationAndSorting helper;
        private ProductService prodService;
        

        public ClientProductsController()
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
            var products = prodService.GetAllProductsWithCategory();
            ViewBag.PD = string.IsNullOrEmpty(sortOrder) ? "PriceDesc" : "";
            ViewBag.PA = sortOrder == "PriceAsc" ? "PriceDesc" : "PriceAsc";
            ViewBag.NA = sortOrder == "NameAsc" ? "NameDesc" : "NameAsc";
            ViewBag.ND = sortOrder == "NameDesc" ? "NameAsc" : "NameDesc";
            return products.ToList();
        }

        public ActionResult IndexCollection(string category, string kind, string searchProduct, int? page, int? pSize, string sortOrder)
        {
            ViewBag.Category = category;
            ViewBag.Kind = kind;
            List<Product> products = Filtering(sortOrder);

            products = helper.Filter(searchProduct, products);

            products = helper.Sorting(sortOrder, products);

            int pageSize, pageNumber;
            helper.PaginationSecondView(pSize, page, out pageSize, out pageNumber);

            if (kind is null)
            {
                return View(products.Where(x => x.Category.Title == category).ToPagedList(pageNumber, pageSize));
            }

            return View(products.Where(x => x.Category.Title == category && x.Kind == kind).ToPagedList(pageNumber, pageSize));
        }

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
