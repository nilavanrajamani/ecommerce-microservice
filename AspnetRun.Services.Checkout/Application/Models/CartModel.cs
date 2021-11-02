using AspnetRun.Services.Basket.Application.Models.Base;
using System.Collections.Generic;

namespace AspnetRun.Services.Basket.Application.Models
{
    public class CartModel : BaseModel
    {
        public string UserName { get; set; }
        public List<CartItemModel> Items { get; set; } = new List<CartItemModel>();
    }
}
