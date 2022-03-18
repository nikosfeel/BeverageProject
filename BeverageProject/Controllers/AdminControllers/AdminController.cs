using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers.AdminControllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //----------Side Bar Start----------
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult CustomerOrders()
        {
            return View();
        }
        public ActionResult CustomerInvoice()
        {
            return View();
        }
        public ActionResult PrintCustomerInvoice()
        {
            return View();
        }
        public ActionResult AllProducts(string category)
        {
            if (category is null)
            {
                return View(db.Beers.ToList());
            }
            var beers = db.Beers.Where(x => x.Category.Kind == category).ToList();
            return View(beers);
        }
        public ActionResult AllBeers()
        {
            return View();
        }
        public ActionResult AllSpirits()
        {
            return View();
        }
        public ActionResult AllWhiskeys()
        {
            return View();
        }
        public ActionResult AllWines()
        {
            return View();
        }
        public ActionResult MailInbox()
        {
            return View();
        }
        public ActionResult ComposeMail()
        {
            return View();
        }
        public ActionResult ViewMail()
        {
            return View();
        }
        public ActionResult LockScreen()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        //----------Side Bar End----------

        //----------Side Bar Start----------
        public ActionResult UserProfile()
        {
            return View();
        }
        //----------Side Bar End----------
    }
}