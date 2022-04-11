﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }        
        public string Kind { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
