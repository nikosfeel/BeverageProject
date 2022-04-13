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
        public ActionResult CreateProduct(string name, string description, string photoUrl, double price, string category, string kind)
        {
            var categories = db.Categories.ToList();

            var product = new Product()
            {
                Name = name,
                Description = description,
                PhotoUrl = photoUrl,
                Price = price,
                Category = categories.Where(x => x.Title == category).FirstOrDefault(),
                Kind = kind
            };

            db.Products.Add(product);
            db.SaveChanges();

            return View(product);
        }
    }
}