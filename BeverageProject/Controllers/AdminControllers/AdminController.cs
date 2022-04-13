using BeverageProject.Models.ViewModels;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BeverageProject.Controllers.AdminControllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CustomerOrders()
        {
            var orders = db.Orders.Include(x=>x.OrderProducts).ToList();
                       
            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CustomerInformation()
        {
            return View(db.Users.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllProducts()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllBeers()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllSpirits()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllWhiskeys()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllWines()
        {
            return View();
        }
    }
}