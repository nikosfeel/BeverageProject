using Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeverageProject.Models.ViewModels
{
    public class AdminAllProductsViewModel
    {
        public List<BeerCategory> BeerCategories { get; set; }
        public List<WineCategory> WineCategories { get; set; }
        public List<WhiskeyCategory> WhiskeyCategories { get; set; }
        public List<SpiritCategory> SpiritCategories { get; set; }
    }
}