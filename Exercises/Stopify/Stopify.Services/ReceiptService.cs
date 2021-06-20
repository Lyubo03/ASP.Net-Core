namespace Stopify.Services
{
    using Microsoft.EntityFrameworkCore;
    using Stopify.Data;
    using Stopify.Data.Models;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class ReceiptService : IReceiptService
    {
        private readonly StopifyDbContext context;
        private readonly IOrderService orderService;

        public ReceiptService(StopifyDbContext context, IOrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
        }
        public async Task<string> CreateReceipt(string recipientId)
        {
            Receipt receipt = new Receipt
            {
                IssuedOn = DateTime.UtcNow,
                RecipientId = recipientId,
            };

            await orderService.SetOrdersToReceipt(receipt);

            foreach (var order in receipt.Orders)
            {
                await orderService.CompleteOrder(order.Id);
            }

            await this.context.Receipts.AddAsync(receipt);
            var result = await context.SaveChangesAsync();

            return receipt.Id;
        }

        public IQueryable<ReceiptServiceModel> GetAll()
        {
            return this.context.Receipts
                .To<ReceiptServiceModel>();
        }

        public IQueryable<ReceiptServiceModel> GetAllByRecipientId(string recipientId)
        {
            return this.context.Receipts
                .Include(receipt => receipt.Orders)
                .Where(receipt => receipt.RecipientId == recipientId)
                .To<ReceiptServiceModel>();
        }
    }
}