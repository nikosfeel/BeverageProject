using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Categories
{
    public class BeerCategory : ICategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Beer";
        public string Kind { get; set; }

        //Navigation Property       
        public ICollection<Beer> Beers { get; set; }
    }
}
