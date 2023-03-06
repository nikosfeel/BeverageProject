using BeverageProject.Models.ViewModels;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersistenceLayerGeneric.Repositories;

namespace BeverageProject.Controllers.AdminControllers
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