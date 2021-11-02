using AspnetRun.Web.Extensions;
using AspnetRun.Web.Interfaces.Core;
using AspnetRun.Web.ViewModels.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services.Core
{
    public class CartService : ICartService
    {
        private HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddItem(string userName, int productId)
        {            
            await _httpClient.PostAsJson($"/api/cart", new CartItem() { UserName = userName, ProductId = productId });
        }

        public Task ClearCart(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<CartModel> GetCartByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem(int cartId, int cartItemId)
        {
            throw new NotImplementedException();
        }
    }
}
