using AspnetRun.Services.Basket.ViewModel;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Interfaces
{
    public interface ICheckOutPageService
    {
        Task<CartViewModel> GetCart(string userName);        
        Task CheckOut(OrderViewModel order, string userName);
    }
}
