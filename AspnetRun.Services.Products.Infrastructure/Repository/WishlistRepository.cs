using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Repositories;
using AspnetRun.Services.Products.Core.Specification;
using AspnetRun.Services.Products.Infrastructure.Data;
using AspnetRun.Services.Products.Infrastructure.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Infrastructure.Repository
{
    public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Wishlist> GetByUserNameAsync(string userName)
        {
            var spec = new WishlistWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
