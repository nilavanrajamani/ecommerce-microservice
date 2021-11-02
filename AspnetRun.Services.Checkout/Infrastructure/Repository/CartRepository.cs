using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Services.Basket.Core.Entities;
using AspnetRun.Services.Basket.Core.Repositories;
using AspnetRun.Services.Basket.Core.Specifications;
using AspnetRun.Services.Basket.Infrastructure.Data;
using AspnetRun.Services.Basket.Infrastructure.Repository.Base;

namespace AspnetRun.Services.Basket.Infrastructure.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> GetByUserNameAsync(string userName)
        {
            var spec = new CartWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
