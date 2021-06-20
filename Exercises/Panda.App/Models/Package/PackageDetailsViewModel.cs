namespace Panda.App.Models.Package
{
    public class PackageDetailsViewModel
    {
        public string Id { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
        public string EstimatedDelivaryDate { get; set; }
        public string Recipient { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
    }
}