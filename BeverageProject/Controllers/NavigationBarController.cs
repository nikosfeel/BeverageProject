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
            viewModel.Products = db.Products.GroupBy(x => x.Category.Title).Select(x => x.FirstOrDefault()).ToList();
            


            return PartialView("ClientComponents/_NavigationBar", viewModel);
        }
    }
}