using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<Product> GetProductBySlug(string slug);
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
        Task<Product> GetProductByIdWithCategoryAsync(int productId);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);        
    }
}
