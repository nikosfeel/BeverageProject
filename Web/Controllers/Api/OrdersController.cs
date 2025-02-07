﻿using ApplicationDatabase;
using PersistenceLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers.Api
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : ApiController
    {
        private ApplicationDbContext db;
        private OrderProductsRepository _OrderProductsRepo;
        private OrderRepository _OrdersRepo;

        public OrdersController(ApplicationDbContext context)
        {
            db = context;
            _OrderProductsRepo = new OrderProductsRepository(db);
            _OrdersRepo = new OrderRepository(db);
        }
        public IHttpActionResult GetOrders()
        {
            var orders = _OrdersRepo.GetAll();
            return Ok(orders);
        }
        public IHttpActionResult GetOrder(int id)
        {
            var order = _OrderProductsRepo.GetOrderProducts(id);
            return Ok(order);
        }
        [HttpPut]
        public IHttpActionResult MarkAsShipped(int id)
        {
            var order = _OrdersRepo.MarkAsShipped(id);
            return Ok();
        }

    }
}