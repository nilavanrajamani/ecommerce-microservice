using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Repositories;
using AspnetRun.Services.Products.Core.Specification;
using AspnetRun.Services.Products.Infrastructure.Data;
using AspnetRun.Services.Products.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Infrastructure.Repository
{
    public class CompareRepository : Repository<Compare>, ICompareRepository
    {
        public CompareRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Compare> GetByUserNameAsync(string userName)
        {
            var spec = new CompareWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
