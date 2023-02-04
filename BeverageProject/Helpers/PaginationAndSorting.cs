using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BeverageProject.Helpers
{
    public static class PaginationAndSorting
    {
        public static List<Product> Sorting(this List<Product> products, string sortOrder)
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

        public static void Pagination(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 10;
        }

        public static void PaginationSecondView(int? pSize, int? page, out int pageSize, out int pageNumber)
        {
            pageNumber = page ?? 1;
            pageSize = pSize ?? 12;
        }

        public static List<Product> Filter(this List<Product> products, string searchProduct)
        {
            if (!string.IsNullOrEmpty(searchProduct))
            {
                products = products.Where(t => t.Name.ToUpper().Contains(searchProduct.ToUpper())).ToList();
            }
            return products;
        }
    }
}