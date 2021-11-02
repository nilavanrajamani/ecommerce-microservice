using AspnetRun.Services.Basket.Application.Models.Base;

namespace AspnetRun.Services.Basket.Application.Models
{
    public class CartItemModel : BaseModel
    {
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}

