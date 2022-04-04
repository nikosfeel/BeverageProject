using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Orders
{
    public class OrderProduct
    {
        [Key,Column(Order = 1)]
        
        public int OrderId { get; set; }
        
        public string Product { get; set; }
        public Order Order { get; set; } = new Order();
    }
}
