using Entities.Categories;
using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeverageProject.Models.ViewModels
{
    public class AdminAllProductsViewModel
    {
        public List<Beer> Beers { get; set; }
        public List<Wine> Wines { get; set; }
        public List<Whiskey> Whiskeys { get; set; }
        public List<Spirit> Spirits { get; set; }
    }
}