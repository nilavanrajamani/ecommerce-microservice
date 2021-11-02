﻿using AspnetRun.Services.Basket.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartModel> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int cartItemId);
        Task ClearCart(string userName);
    }
}
