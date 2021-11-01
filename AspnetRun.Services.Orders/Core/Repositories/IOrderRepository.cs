using AspnetRun.Services.Orders.Core.Entities;
using AspnetRun.Services.Orders.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Services.Orders.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUserNameAsync(string userName);
    }
}
