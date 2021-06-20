namespace Panda.Services.Receipt
{
    using Domain;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IReceiptService
    {
        Receipt GetById(string id);
        IQueryable<Receipt> GetReceipts();
        void AddReceipt(Receipt receipt);
    }
}