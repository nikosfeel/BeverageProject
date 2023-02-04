using BeverageProject.Models.ViewModels;
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
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCreateModel product)
        {
            if (ModelState.IsValid)
            {
                var model = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    PhotoUrl = product.PhotoUrl,
                    Price = product.Price,
                    Category = db.Categories.Where(x => x.Title == product.Category).FirstOrDefault(),
                    Kind = product.Kind
                };

                db.Products.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}