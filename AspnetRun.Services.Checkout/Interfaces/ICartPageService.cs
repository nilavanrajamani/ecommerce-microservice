using AspnetRun.Services.Basket.ViewModel;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Interfaces
{
    public interface ICartComponentService
    {
        Task<CartViewModel> GetCart(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int cartItemId);
    }
}
