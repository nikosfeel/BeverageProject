using Entities.Items;
using Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersistenceLayerGeneric.Dtos
{
    public class OrderProductsDto
    {
        public Order Order { get; set; }

        public IList<Item> Products { get; set; }
    }
}