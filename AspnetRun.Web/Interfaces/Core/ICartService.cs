using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces.Core
{
    public interface ICartService
    {
        Task<CartModel> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int cartItemId);
        Task ClearCart(string userName);
    }
}
