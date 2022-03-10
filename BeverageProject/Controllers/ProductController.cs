using Entities.Items;
using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            var beers = db.Beers.ToList();
            var spirits = db.Spirits.ToList();
            var wines = db.Wines.ToList();
            var whiskeys = db.Whiskeys.ToList();

            ItemModel itemModel = new ItemModel(beers, spirits, wines, whiskeys);
            ViewBag.Beers = itemModel.findAllBeers();
            ViewBag.Spirits = itemModel.findAllSpirits();
            ViewBag.Wines = itemModel.findAllWines();
            ViewBag.Whiskeys = itemModel.findAllWhiskeys();
            return View();
        }
    }
}