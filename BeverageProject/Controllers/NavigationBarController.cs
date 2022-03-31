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
            viewModel.Beers = db.Beers.GroupBy(x => x.Kind).Select(x => x.FirstOrDefault()).ToList();
            viewModel.Wines = db.Wines.GroupBy(x => x.Kind).Select(x => x.FirstOrDefault()).ToList();
            viewModel.Whiskeys = db.Whiskeys.GroupBy(x => x.Kind).Select(x => x.FirstOrDefault()).ToList();
            viewModel.Spirits = db.Spirits.GroupBy(x => x.Kind).Select(x => x.FirstOrDefault()).ToList();


            return PartialView("ClientComponents/_NavigationBar", viewModel);
        }
    }
}