using BeverageProject.Models.ViewModels;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BeverageProject.Controllers
{
    public class NavigationBarController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: NavigationBar
        public ActionResult NavBarCategories()
        {
            NavBarViewModel viewModel = new NavBarViewModel();
            viewModel.Beers = db.Beers.ToList();
            viewModel.Wines = db.Wines.ToList();
            viewModel.Spirits = db.Spirits.ToList();
            viewModel.Whiskeys = db.Whiskeys.ToList();
            viewModel.BeerCategories = db.BeerCategories.ToList();
            viewModel.WineCategories = db.WineCategories.ToList();
            viewModel.WhiskeyCategories = db.WhiskeyCategories.ToList();
            viewModel.SpiritCategories = db.SpiritCategories.ToList();



            return PartialView("ClientComponents/_NavigationBar", viewModel);
        }
    }
}