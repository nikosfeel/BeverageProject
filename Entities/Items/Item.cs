using Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Items
{
    public class Item
    {
        public Beer Beer { get; set; }
        public Spirit Spirit { get; set; }
        public Wine Wine { get; set; }
        public Whiskey Whiskey { get; set; }

        public int Quantity { get; set; }
    }
}
