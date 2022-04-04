﻿using Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double Price { get; set; }
        string PhotoUrl { get; set; }
        string Kind { get; set; }

        ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
