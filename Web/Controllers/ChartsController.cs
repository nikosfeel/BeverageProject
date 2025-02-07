﻿using Entities.Products;
using ApplicationDatabase;
using PersistenceLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ChartsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly ProductService service;
        public ChartsController(ApplicationDbContext context)
        {
            db = context;
            service = new ProductService(db);
        }

        public ActionResult BeerCharts()
        {
            return View();
        }

        public ActionResult SpiritCharts()
        {
            return View();
        }

        public ActionResult WhiskeyCharts()
        {
            return View();
        }

        public ActionResult WineCharts()
        {
            return View();
        }

        public ActionResult BeerAreaAndColumnChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Beer").Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BeerPieChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Beer").Select(x => new { name = x.Kind, y = x.Kind.Count() }).Distinct();

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SpiritAreaAndColumnChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Spirit").Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SpiritPieChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Spirit").Select(x => new { name = x.Kind, y = x.Kind.Count() }).Distinct();

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WhiskeyAreaAndColumnChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Whiskey").Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WhiskeyPieChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Whiskey").Select(x => new { name = x.Kind, y = x.Kind.Count() }).Distinct();

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WineAreaAndColumnChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Wine").Select(x => new { name = x.Name, y = x.Price });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult WinePieChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.Where(x => x.Category.Title == "Wine").Select(x => new { name = x.Kind, y = x.Kind.Count() }).Distinct();

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllProductsChart()
        {
            var products = service.GetAllProductsWithCategory();

            var dataforchart = products.GroupBy(x => x.Category.Title).Select(x => new { name = x.Key, y = x.Sum(y => y.Kind.Count()) });

            return Json(dataforchart, JsonRequestBehavior.AllowGet);
        }
    }
}