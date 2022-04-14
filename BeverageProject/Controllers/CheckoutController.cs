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
using PayPal.Api;
using BeverageProject.Models;

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
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult CreateOrder(OrderDto orderDto)
        {
            List<Entities.Items.Item> cart = (List<Entities.Items.Item>)Session["cart"];
            Entities.Orders.Order order = new Entities.Orders.Order();
            order.Address = orderDto.Address;
            order.City = orderDto.City;
            order.Email = orderDto.Email;
            order.Phone = orderDto.Phone;
            order.PostalCode = orderDto.PostalCode;
            order.FullName = orderDto.FullName;
            order.Total = 0;
            order.OrderDate = orderDto.OrderDate;
            order.Total = orderDto.Total;
                     
            foreach (var item in cart)
            {
                order.Total += Convert.ToDecimal(item.Product.Price);
                order.Products.Add(item.Product);

            }
            //arxika find db.products.find ola ta products me vash ta id ths order.products

            List<Product> tempProducts = new List<Product>();
            foreach (var prod in order.Products)
            {
                var temp = db.Products.Find(prod.ProductId);
                tempProducts.Add(temp);
            }
            order.Products = tempProducts;

            db.Entry(order).State = EntityState.Added;
            db.SaveChanges();
            cart.Clear();

            return RedirectToAction("Success");
        }

        // paypal payments
        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList()
            {
                items = new List<PayPal.Api.Item>() 
            };

            List<Entities.Items.Item> listCarts = (List<Entities.Items.Item>)Session["cart"];

            foreach(var cart in listCarts)
            {
                listItems.items.Add(new PayPal.Api.Item()
                {
                    name = cart.Product.Name,
                    currency = "EUR",
                    price = cart.Product.Price.ToString(),
                    quantity = cart.Quantity.ToString(),
                    sku = "sku"
                }); 
            }

            var payer = new Payer() { payment_method = "paypal" };

            // configure RedirectUrls
            var redirect = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl,
            };

            //details
            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = listCarts.Sum(item => item.Product.Price * item.Quantity).ToString()
            };

            //create amount
            var amount = new Amount()
            {
                currency = "EUR",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),         
                details = details
            };

            // creating Transaction
            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Beverage Testing Description",
                invoice_number = Convert.ToString(new Random().Next(100000)),
                amount = amount,
                item_list  = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirect

            };

            return payment.Create(apiContext);
        }


         //  Execute payment

        private Payment ExecutePayment(APIContext apiContext, string payerid,string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerid
            };

            payment = new Payment() { id = paymentId };

            return payment.Execute(apiContext, paymentExecution);
        }

        // Payment with paypal

        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if(string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Checkout/PaymentWithPaypal?";
                    var guid = Convert.ToString(new Random().Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseURI + "guid=" + guid);

                    var links = createdPayment.links.GetEnumerator();

                    string paypalRedirectUrl = string.Empty;


                    while (links.MoveNext())
                    {
                        Links link = links.Current;

                        if(link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);

                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session["guid"] as string);

                    if (executedPayment.state.ToLower() !="approved")
                    {
                        return View("Failure");
                    }
                }
            }
            catch(Exception ex)
            {
                PaypalLogger.Log("Error" + ex.Message);
                return View("Failure");
            }

            return View("Success");
        }

    }
}