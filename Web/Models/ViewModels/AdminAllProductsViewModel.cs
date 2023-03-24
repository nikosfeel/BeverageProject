using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class AdminAllProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}