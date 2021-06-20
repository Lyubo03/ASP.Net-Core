namespace Stopify.Web.ViewModels.Receipt.Details
{
    using AutoMapper;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using System;
    using System.Collections.Generic;

    public class ReceiptDetailsViewModel : IMapFrom<ReceiptServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }
        public string Recipient { get; set; }
        public DateTime IssuedOn { get; set; }
        public List<ReceiptDetailsOrderViewModel> Orders { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServiceModel, ReceiptDetailsViewModel>()
                .ForMember(dest => dest.Recipient,
                opts => opts.MapFrom(origin => origin.Recipient.UserName));
        }
    }
}