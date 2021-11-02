using AspnetRun.Services.Basket.ViewModel.Base;
using System.Collections.Generic;

namespace AspnetRun.Services.Basket.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public decimal GrandTotal
        {
            get
            {
                decimal grandTotal = 0;
                foreach (var item in Items)
                {
                    grandTotal += item.TotalPrice;
                }

                return grandTotal;
            }
        }
    }
}
