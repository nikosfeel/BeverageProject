using Entities;
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
        // GET: ProductCreate
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PhotoUrl,Kind")] IProduct product)
        {
            if (ModelState.IsValid)
            {                
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}