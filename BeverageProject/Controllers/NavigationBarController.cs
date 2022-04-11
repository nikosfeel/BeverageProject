using BeverageProject.Models.ViewModels;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities;

namespace BeverageProject.Controllers
{
    public class NavigationBarController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: NavigationBar
        public ActionResult NavBarCategories()
        {
            
            NavViewModel viewModel = new NavViewModel();
            viewModel.Products = db.Products.GroupBy(x=>x.Kind).Select(c=>c.FirstOrDefault()).ToList();
            viewModel.Categories = db.Categories.ToList();
            


            return PartialView("ClientComponents/_NavigationBar", viewModel);
        }
    }
}