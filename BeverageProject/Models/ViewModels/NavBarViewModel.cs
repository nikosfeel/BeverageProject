using Entities;
using Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeverageProject.Models.ViewModels
{
    public class NavBarViewModel
    {
        public List<ICategory> Categories { get; set; }
        public List<IProduct> Products { get; set; }
        
    }
}