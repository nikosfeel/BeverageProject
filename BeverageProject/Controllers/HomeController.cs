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
            var products = db.Products.OrderByDescending(x => x.ProductId).Take(4).ToList();

            ViewBag.ConfirmationCookie = Request.Cookies.AllKeys.Contains("Confirmation");

            if (!string.IsNullOrEmpty(searchΑllProducts))
            {
                products = products.Where(t => t.Name.ToUpper().Contains(searchΑllProducts.ToUpper())).ToList();
            }

            return View(products);
        }

        public ActionResult Chat()
        {
            return View();
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
        public ActionResult Confirm()
        {
            Response.Cookies.Add(new HttpCookie("Confirmation"));
            return RedirectToAction("Index");
        }
    }
}