using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Categories
{
    public class WhiskeyCategory : ICategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Whiskey";
        public string Kind { get; set; }

        public ICollection<Whiskey> Whiskeys { get; set; }
    }
}
