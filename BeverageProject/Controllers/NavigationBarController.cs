using BeverageProject.Models.ViewModels;
using MyDatabase;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PersistenceLayerGeneric.Repositories;
using Entities.Items;

namespace BeverageProject.Controllers
{
    public class NavigationBarController : Controller
    {
        private readonly ApplicationDbContext db;
        private ProductService prodService;
        private CategoryService catService;
        public NavigationBarController(ApplicationDbContext context)
        {
            db = context;
            prodService = new ProductService(db);
            catService = new CategoryService(db);
        }

        // GET: NavigationBar
        public ActionResult NavBarCategories()
        {

            NavViewModel viewModel = new NavViewModel();
            viewModel.Products = prodService.GetAll().OrderBy(x => x.Kind).GroupBy(x => x.Kind).Select(c => c.FirstOrDefault()).ToList();
            viewModel.Categories = catService.GetAll();

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();

                Session["cart"] = cart;
            }


            return PartialView("ClientComponents/_NavigationBar", viewModel);
        }
    }
}