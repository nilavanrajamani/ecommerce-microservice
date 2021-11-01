using AspnetRun.Services.Orders.Core.Entities;
using AspnetRun.Services.Orders.Core.Repositories;
using AspnetRun.Services.Orders.Infrastructure.Data;
using AspnetRun.Services.Orders.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Services.Orders.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrderByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
