using Entities;
using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers.AdminControllers
{
    public class ProductCreateController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            return View("~/Views/Admin/AllProducts.cshtml");
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "Id,Name,Description,Price,PhotoUrl,Kind,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}