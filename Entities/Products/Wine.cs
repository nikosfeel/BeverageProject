using Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Products
{
    public class Wine : Product, IProduct
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PhotoUrl { get; set; }
        

        //Foreign Key For Category
        public WineCategory Category { get; set; }
    }
}
