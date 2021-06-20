namespace Panda.App.Models.Package
{
    using Panda.Domain;

    public class PackageCreateBindingModel
    {
        public string Description { get; set; }
        public double Weight { get; set; }
        public string ShippingAddress { get; set; }
        public string Recipient { get; set; }
    }
}