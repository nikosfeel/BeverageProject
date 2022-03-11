using Entities.Items;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(string id)
        {
            var beers = db.Beers.ToList();
            var spirits = db.Spirits.ToList();
            var wines = db.Wines.ToList();
            var whiskeys = db.Whiskeys.ToList();
            ItemModel itemModel = new ItemModel(beers, spirits, wines, whiskeys);

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item
                {
                    Beer = itemModel.FindBeer(id),
                    Spirit = itemModel.FindSpirit(id),
                    Wine = itemModel.FindWine(id),
                    Whiskey = itemModel.FindWhiskey(id),
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != 1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item
                    {
                        Beer = itemModel.FindBeer(id),
                        Spirit = itemModel.FindSpirit(id),
                        Wine = itemModel.FindWine(id),
                        Whiskey = itemModel.FindWhiskey(id),
                        Quantity = 1
                    });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Beer.Id.Equals(id) && cart[i].Spirit.Id.Equals(id) && cart[i].Wine.Id.Equals(id) && cart[i].Whiskey.Id.Equals(id))
                {
                    return i;
                }              
            }
            return -1;
        }
    }
}