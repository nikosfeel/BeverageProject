using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string OriginCountry { get; set; }


        //Navigation properties
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
