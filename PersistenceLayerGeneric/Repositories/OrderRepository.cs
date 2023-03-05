using Entities.Orders;
using Entities.Products;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PersistenceLayerGeneric.Repositories
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool MarkAsShipped(int orderId)
        {
            var order = Context.Orders.Find(orderId);
            order.HasBeenShipped = !order.HasBeenShipped;

            Context.Entry(order).State = EntityState.Modified;
            Context.SaveChanges();

            return true;
        }
    }
}
