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
        public IProduct Product { get; set; }

        public int Quantity { get; set; }
     
    }
}
