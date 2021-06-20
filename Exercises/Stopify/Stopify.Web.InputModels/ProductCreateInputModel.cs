namespace Stopify.Web.InputModels
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateInputModel : IMapTo<ProductServiceModel>, IHaveCustomMappings
    {
        [Required (ErrorMessage = "Name is necessary!")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public IFormFile Picture{ get; set; }

        [Required]
        public string ProductType { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductCreateInputModel, ProductServiceModel>()
                .ForMember(dest => dest.ProductType,
                opts => opts.MapFrom(origin => new ProductTypeServiceModel
                {
                    Name = origin.ProductType
                }));
        }
    }
}