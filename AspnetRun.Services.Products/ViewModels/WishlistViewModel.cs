using AspnetRun.Services.Products.ViewModels.Base;
using System.Collections.Generic;

namespace AspnetRun.Services.Products.ViewModels
{
    public class WishlistViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<ProductViewModel> Items { get; set; } = new List<ProductViewModel>();
    }
}
