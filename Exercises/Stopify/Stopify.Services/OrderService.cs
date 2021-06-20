namespace Stopify.Services
{
    using Microsoft.EntityFrameworkCore;
    using Stopify.Data;
    using Stopify.Data.Models;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class OrderService : IOrderService
    {
        private readonly StopifyDbContext context;

        public OrderService(StopifyDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CompleteOrder(string orderId)
        {
            var order = await context.Orders.SingleOrDefaultAsync(o => o.Id == orderId);

            order.Status = await context.OrderStatuses
                .SingleOrDefaultAsync(x => x.Name == "Completed");

            context.Update(order);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> CreateOrder(OrderServiceModel model)
        {
            var order = model.To<Order>();

            order.Status = await context.OrderStatuses
                .SingleOrDefaultAsync(status => status.Name == "Active");

            order.IssuedOn = DateTime.UtcNow;

            await this.context.Orders.AddAsync(order);
            int result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<OrderServiceModel> GetAll()
        {
            return this.context.Orders.To<OrderServiceModel>();
        }

        public async Task<bool> IncreaseQuantity(string orderId)
        {
            var orderFromDb = await context.Orders
                .SingleOrDefaultAsync(order => order.Id == orderId);

            orderFromDb.Quantity--;

            context.Update(orderFromDb);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ReduceQuantity(string orderId)
        {
            var orderFromDb = await context.Orders
               .SingleOrDefaultAsync(order => order.Id == orderId);

            orderFromDb.Quantity--;

            context.Update(orderFromDb);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task SetOrdersToReceipt(Receipt receipt)
        {
            List<Order> ordersFromDb = await this.context.Orders.Where(order => order.IssuerId == receipt.RecipientId &&
            order.Status.Name == "Active")
            .ToListAsync();

            receipt.Orders = ordersFromDb;
        }
    }
}