using BeverageProject.Models;
using Entities;
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
            ItemModel productModel = new ItemModel();
            ViewBag.products = productModel.findAllProducts();
            return View();
        }
    }
}