namespace Stopify.Services
{
    using System.Linq;
    using Stopify.Services.Models;
    using System.Threading.Tasks;

    public interface IProductService
    {
        IQueryable<ProductTypeServiceModel> GetAllProductTypes();
        Task<bool> Create(ProductServiceModel createModel);
        Task<bool> CreateProductType(ProductTypeServiceModel createModel);
        IQueryable<ProductServiceModel> GetAllProducts();
        Task<ProductServiceModel> GetByIdAsync(string id);
    }
}