namespace Panda.Services.Receipt
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Panda.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext context;

        public ReceiptService(PandaDbContext context)
        {
            this.context = context;
        }

        public void AddReceipt(Receipt receipt)
        {
            context.Receipts.Add(receipt);
            context.SaveChanges();
        }

        public Receipt GetById(string id)
        {
            var package = context.Receipts
                .Include(x => x.Package)
                .Include(x => x.Recipient)
                .SingleOrDefault(x => x.Id == id);

            return package;
        }

        public IQueryable<Receipt> GetReceipts()
        {
            return context.Receipts
                .Include(x => x.Recipient)
                .Include(x => x.Package);
        }
    }
}