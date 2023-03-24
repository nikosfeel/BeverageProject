using Web.Models.ViewModels;
using ApplicationDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersistenceLayer.Repositories;

namespace Web.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }       
    }
}