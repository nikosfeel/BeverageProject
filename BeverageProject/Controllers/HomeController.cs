using BeverageProject.Models;
using Entities;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace BeverageProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string searchΑllProducts)
        {
            @ViewBag.searchΑllProducts = searchΑllProducts;
            var beers = db.Beers;
            var spirits = db.Spirits;
            var whiskeys = db.Whiskeys;
            var wines = db.Wines.ToList();

            IEnumerable<IProduct> prod = beers;
            var allProducts = prod.Union(spirits).Union(whiskeys).Union(wines).OrderByDescending(x => x.Id).Take(4);

            if (!string.IsNullOrEmpty(searchΑllProducts))
            {
                allProducts = allProducts.Where(t => t.Name.ToUpper().Contains(searchΑllProducts.ToUpper())).ToList();
            }

            return View(allProducts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Your blog page.";

            return View();
        }

        public ActionResult BlogDetails()
        {
            ViewBag.Message = "Your blog-details page.";

            return View();
        }
    }
}