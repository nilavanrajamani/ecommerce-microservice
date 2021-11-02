using AspnetRun.Services.Basket.Core.Entities;
using AspnetRun.Services.Basket.Core.Repositories;
using AspnetRun.Services.Basket.Core.Specifications;
using AspnetRun.Services.Basket.Infrastructure.Data;
using AspnetRun.Services.Basket.Infrastructure.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetProductByIdWithCategoryAsync(int productId)
        {
            var spec = new ProductWithCategorySpecification(productId);
            return (await GetAsync(spec)).FirstOrDefault();
        }
        
    }
}
