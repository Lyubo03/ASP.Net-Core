namespace Stopify.Web.ViewModels.Receipt.Details
{
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    public class ReceiptDetailsOrderViewModel : IMapFrom<OrderServiceModel>
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }

    }
}