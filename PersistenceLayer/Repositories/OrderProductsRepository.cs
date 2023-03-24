using Entities.Orders;
using Entities.Products;
using ApplicationDatabase;
using PersistenceLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PersistenceLayer.Repositories
{
    public class OrderProductsRepository : GenericRepository<OrderProduct>
    {
        public OrderProductsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public OrderProductsDto GetOrderProducts(int orderId)
        {
            var orderProducts = Context.OrderProducts
                .Include(x=>x.Product)
                .Include(x=>x.Order)
                .Where(x=>x.OrderId == orderId)
                .ToList();

            return new OrderProductsDto
            {
                Order = orderProducts.FirstOrDefault().Order,
                Products = orderProducts.Select(x => new Entities.Items.Item
                {
                    Product = x.Product,
                    Quantity = x.Quantity,
                }).ToList()
            };
        } 
    }
}
