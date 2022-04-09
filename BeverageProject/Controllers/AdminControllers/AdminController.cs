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

        //----------Side Bar Start----------
        [Authorize(Roles = "Admin")]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CustomerOrders()
        {
            var orders = db.Orders.ToList();
            
            
            return View(orders);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CustomerInvoice()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult PrintCustomerInvoice()
        {
            return View();
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
        [Authorize(Roles = "Admin")]
        public ActionResult MailInbox()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ComposeMail()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ViewMail()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult LockScreen()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Registration()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult LoginPage()
        {
            return View();
        }
        //----------Side Bar End----------

        //----------Side Bar Start----------
        [Authorize(Roles = "Admin")]
        public ActionResult UserProfile()
        {
            return View();
        }
        //----------Side Bar End----------
    }
}