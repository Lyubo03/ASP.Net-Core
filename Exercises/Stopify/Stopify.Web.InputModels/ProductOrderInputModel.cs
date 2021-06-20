namespace Stopify.Web.InputModels
{
    using AutoMapper;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;

    public class ProductOrderInputModel : IMapTo<OrderServiceModel>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}