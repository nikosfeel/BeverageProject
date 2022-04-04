using BeverageProject.Models.Dtos;
using Entities;
using Entities.Items;
using Entities.Orders;
using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeverageProject.Controllers
{
    public class CheckoutController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult CreateOrder(OrderDto orderDto)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            Order order = new Order();
            order.Address = orderDto.Address;
            order.City = orderDto.City;
            order.Email = orderDto.Email;
            order.Phone = orderDto.Phone;
            order.PostalCode = orderDto.PostalCode;
            order.FullName = orderDto.FullName;
            order.Total = 0;
            order.OrderDate = orderDto.OrderDate;
            
            

            foreach (var item in cart)
            {
                order.Total += Convert.ToDecimal(item.Product.Price);
                order.Products = $"Name: {item.Product.Name} Price:{item.Product.Price} Quantity: {item.Quantity}";
            }


            db.Entry(order).State = EntityState.Added;
            db.SaveChanges();
            cart.Clear();


            return Json(new {status = "Success"});
        }



        public ActionResult PayPal()
        {
            return View();
        }
    }
}