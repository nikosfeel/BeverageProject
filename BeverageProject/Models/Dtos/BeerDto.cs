using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeverageProject.Models.Dtos
{
    public class BeerDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
        public string Kind { get; set; }



    }
}