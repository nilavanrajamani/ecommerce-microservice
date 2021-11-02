using AspnetRun.Services.Basket.Core.Entities;
using AspnetRun.Services.Basket.Core.Repositories.Base;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByIdWithCategoryAsync(int productId);
    }
}
