using BeverageProject.Models;
using Entities;
using Entities.Items;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BeverageProject.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Buy(int? id)
        {
            var beers = db.Beers;
            var spirits = db.Spirits;
            var whiskeys = db.Whiskeys;
            var wines = db.Wines;


            IEnumerable<IProduct> prod = beers;
            var allProducts = prod.Union(spirits).Union(whiskeys).Union(wines);

            ItemModel itemModel = new ItemModel();

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item
                {
                    Product = itemModel.FindProduct(id),
                    
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item
                    {
                        Product = itemModel.FindProduct(id),

                        Quantity = 1
                    });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult ButtonUp(int? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart[index].Quantity++;
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult ButtonDown(int? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;                
            }            
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int isExist(int? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }              
            }
            return -1;
        }
    }
}