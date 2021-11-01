using AspnetRun.Services.Orders.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Services.Orders.Interfaces
{
    public interface IOrderService
    {        
        Task<OrderModel> CheckOut(OrderModel orderModel);
    }
}
