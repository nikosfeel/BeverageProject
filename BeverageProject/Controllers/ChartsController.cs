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

        public ActionResult ProductChart()
        {
            return View();
        }

        public ActionResult GetProductChartData()
        {
            List<Product> products = db.Products.ToList();

            var dataforchart = products.Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult TEST(string category, string kind)
        //{
        //    List<Product> products = db.Products.ToList();

        //    var dataforchart = products.Select(x => new { name = x.Category.Title = category,  y = x.Kind = kind});

        //    return Json(dataforchart, JsonRequestBehavior.AllowGet);
        //}
    }
}