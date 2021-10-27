using AspnetRun.Services.Products.Application.Models.Base;
using System.Collections.Generic;

namespace AspnetRun.Services.Products.Application.Models
{
    public class WishlistModel : BaseModel
    {
        public string UserName { get; set; }
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
    }
}
