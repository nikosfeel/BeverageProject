using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BeverageProject.Controllers.HelperMethods
{
    public class PaginationAndSorting
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public List<Product> Sorting(string sortOrder, List<Product> products)
        {
            switch (sortOrder)
            {
                case "PriceDesc": products = products.OrderByDescending(x => x.Price).ToList(); break;
                case "PriceAsc": products = products.OrderBy(x => x.Price).ToList(); break;
                case "NameAsc": products = products.OrderBy(x => x.Name).ToList(); break;
                case "NameDesc": products = products.OrderByDescending(x => x.Name).ToList(); break;
                default: products = products.OrderBy(x => x.Price).ToList(); break;

            }
            return products;
        }

        public void Pagination(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 10;
        }

        public void PaginationSecondView(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 12;
        }

        public List<Product> Filter(string searchProduct, List<Product> products)
        {
            if (!string.IsNullOrEmpty(searchProduct))
            {
                products = products.Where(t => t.Name.ToUpper().Contains(searchProduct.ToUpper())).ToList();
            }
            return products;
        }
    }
}