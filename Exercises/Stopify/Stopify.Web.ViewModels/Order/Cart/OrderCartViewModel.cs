namespace Stopify.Web.ViewModels.Order.Cart
{
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;

    public class OrderCartViewModel : IMapFrom<OrderServiceModel>
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductPicture { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}