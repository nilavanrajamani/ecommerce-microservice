using AspnetRun.Services.Basket.Core.Entities.Base;

namespace AspnetRun.Services.Basket.Core.Entities
{
    public class CartItem : Entity
    {       
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
