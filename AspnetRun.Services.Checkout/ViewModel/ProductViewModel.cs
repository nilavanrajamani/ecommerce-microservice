using AspnetRun.Services.Basket.ViewModel.Base;

namespace AspnetRun.Services.Basket.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }        
        public decimal? UnitPrice { get; set; }
        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
