using BeverageProject.Models.ViewModels;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities;
using PersistenceLayerGeneric.Repositories;
using Entities.Products;

namespace BeverageProject.Controllers
{
    public class NavigationBarController : Controller
    {
        private ApplicationDbContext db;
        private ProductService prodService;
        private CategoryService catService;
        public NavigationBarController()
        {
            db = new ApplicationDbContext();
            prodService = new ProductService(db);
            catService = new CategoryService(db);
        }

        // GET: NavigationBar
        public ActionResult NavBarCategories()
        {

            NavViewModel viewModel = new NavViewModel();
            viewModel.Products = prodService.GetAll().OrderBy(x => x.Kind).GroupBy(x => x.Kind).Select(c => c.FirstOrDefault()).ToList();
            viewModel.Categories = catService.GetAll();



            return PartialView("ClientComponents/_NavigationBar", viewModel);
        }
    }
}