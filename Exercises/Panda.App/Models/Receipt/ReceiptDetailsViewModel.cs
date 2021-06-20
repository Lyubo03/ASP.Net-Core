namespace Panda.App.Models.Receipt
{
    public class ReceiptDetailsViewModel
    {
        public string Id { get; set; }
        public string Total { get; set; }
        public string IssuedOn { get; set; }
        public string Recipient { get; set; }
        public string Weight { get; set; }
        public string Description { get; set; }
        public string DeliveryAddress { get; set; }

    }
}