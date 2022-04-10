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

        public ActionResult CreateBeer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBeer([Bind(Include = "Id,Name,Description,Price,PhotoUrl,Kind")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beer);
        }

        public ActionResult CreateSpirit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSpirit([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Spirit spirit)
        {
            if (ModelState.IsValid)
            {
                db.Spirits.Add(spirit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spirit);
        }

        public ActionResult CreateWhiskey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWhiskey([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Whiskey whiskey)
        {
            if (ModelState.IsValid)
            {
                db.Whiskeys.Add(whiskey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whiskey);
        }

        public ActionResult CreateWine()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWine([Bind(Include = "Id,Name,Description,Price,PhotoUrl")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Wines.Add(wine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wine);
        }
    }
}