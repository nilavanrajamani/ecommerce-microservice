using AspnetRun.Services.Products.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Application.Interfaces
{
    public interface IWishlistService
    {
        Task<WishlistModel> GetWishlistByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int wishlistId, int productId);
    }
}
