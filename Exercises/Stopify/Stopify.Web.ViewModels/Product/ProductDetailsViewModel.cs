namespace Stopify.Web.ViewModels.Product
{
    using System;
    using Services.Mapping;
    using Services.Models;

    public class ProductDetailsViewModel : IMapFrom<ProductServiceModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ProductTypeName { get; set; }

        public DateTime ManufacturedOn { get; set; }

        public string Picture { get; set; }
    }
}