using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers
{
    public class ChartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult BeerChart()
        {
            return View();
        }

        public ActionResult SpiritChart()
        {
            return View();
        }

        public ActionResult GetBeerChartData()
        {
            List<Beer> beers = db.Beers.ToList();

            var dataforchart = beers.Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSpiritChartData()
        {
            List<Spirit> spirits = db.Spirits.ToList();

            var dataforchart = spirits.Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }
    }
}