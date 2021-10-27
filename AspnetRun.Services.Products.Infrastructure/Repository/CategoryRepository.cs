using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Repositories;
using AspnetRun.Services.Products.Infrastructure.Data;
using AspnetRun.Services.Products.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }
    }
}
