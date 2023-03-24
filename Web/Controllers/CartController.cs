using Web.Models;
using Entities;
using Entities.Items;
using ApplicationDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return Redirect(Request.UrlReferrer.ToString());
        }
        public JsonResult GetCartItems()
        {
            return Json(Session["cart"], JsonRequestBehavior.AllowGet);
        }
        public ActionResult Buy(int? id)
        {
            ItemModel itemModel = new ItemModel();

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

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Remove(int? id)
        {
            if (id == null)
                return Json("", JsonRequestBehavior.AllowGet);

            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ButtonUp(int? id)
        {
            if (id == null) 
                return Json("", JsonRequestBehavior.AllowGet);
            
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart[index].Quantity++;
            Session["cart"] = cart;
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ButtonDown(int? id)
        {
            if (id == null)
                return Json("", JsonRequestBehavior.AllowGet);

            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--;                
            }            
            Session["cart"] = cart;
            return Json("", JsonRequestBehavior.AllowGet);
        }

        private int isExist(int? id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }              
            }
            return -1;
        }
    }
}