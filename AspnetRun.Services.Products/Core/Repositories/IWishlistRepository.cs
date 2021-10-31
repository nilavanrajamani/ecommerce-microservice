using System.Threading.Tasks;
using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Repositories.Base;

namespace AspnetRun.Services.Products.Core.Repositories
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Task<Wishlist> GetByUserNameAsync(string userName);
    }
}
