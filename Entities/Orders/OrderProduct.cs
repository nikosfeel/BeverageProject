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
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Key, Column(Order = 2)]
        public int ProductId { get; set; }
        public IProduct Product { get; set; }
        public Order Order { get; set; } = new Order();
    }
}
