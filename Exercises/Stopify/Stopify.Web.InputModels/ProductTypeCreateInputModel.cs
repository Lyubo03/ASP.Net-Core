namespace Stopify.Web.InputModels
{
    using Stopify.Services.Mapping;
    using Stopify.Services.Models;

    public class ProductTypeCreateInputModel : IMapTo<ProductTypeServiceModel>
    {
        public string Name { get; set; }
    }
}