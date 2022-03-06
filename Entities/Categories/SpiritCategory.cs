using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Categories
{
    public class SpiritCategory : ICategory
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Spirit";
        public string Kind { get; set; }

        //Navigation Property
        public ICollection<Spirit> Spirits { get; set; }
    }
}
