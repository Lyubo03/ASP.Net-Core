namespace Stopify.Web.ViewModels.Receipt.Profile
{
    using AutoMapper;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using System;
    using System.Linq;

    public class ReceiptProfileViewModel : IMapFrom<ReceiptServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }
        public DateTime IssuedOn { get; set; }
        public decimal Total { get; set; }
        public int Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServiceModel, ReceiptProfileViewModel>()
                .ForMember(dest => dest.Total,
                opts => opts.MapFrom(origin => origin.Orders
                                .Sum(order => order.Product.Price * order.Quantity)))
                .ForMember(dest => dest.Products,
                opts => opts.MapFrom(origin => origin.Orders
                .Sum(order => order.Quantity * order.Quantity))); ;
        }
    }
}