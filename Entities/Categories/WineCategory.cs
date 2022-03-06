using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Categories
{
    public class WineCategory : ICategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Wine";
        public string Kind { get; set; }

        //Nagivagtion Property
        public ICollection<Wine> Wines { get; set; }
    }
}
