using AspnetRun.Web.Base;
using System.Collections.Generic;

namespace AspnetRun.Web
{
    public class CartModel : BaseModel
    {
        public string UserName { get; set; }
        public List<CartItemModel> Items { get; set; } = new List<CartItemModel>();
    }
}
