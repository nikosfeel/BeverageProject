using Web.Models.ViewModels;
using ApplicationDatabase;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using Entities;
using Entities.Products;
using System.Data.Entity.Infrastructure;
using PersistenceLayer.Repositories;

namespace Web.Controllers.Api
{
    [Authorize(Roles = "Admin")]
    public class AllProductsController : ApiController
    {
        private readonly ApplicationDbContext _db;
        private readonly ProductService prodService;
        public AllProductsController(ApplicationDbContext context)
        {
            _db = context;
            prodService = new ProductService(_db);
        }
        public IHttpActionResult Get()
        {
            var products = prodService
                .GetAllProductsWithCategory()
                .Select(product => new
                {
                    product.ProductId,
                    product.Name,
                    product.Description,
                    product.PhotoUrl,
                    product.Price,
                    product.Kind,
                    Category = product.Category.Title,
                }).ToList();

            return Ok(products);
        }
        public IHttpActionResult GetById(int id)
        {
            var products = prodService.Get(id);

            return Ok(products);
        }
        public IHttpActionResult Put(Product product)
        {
            var prod = prodService.Edit(product);

            return Ok(prod);
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            var product = prodService.Delete(id);

            if (product == null)
                return BadRequest();

            return Ok(product);
        }
    }
}
