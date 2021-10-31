using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Repositories.Base;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Core.Repositories
{
    public interface ICompareRepository : IRepository<Compare>
    {
        Task<Compare> GetByUserNameAsync(string userName);
    }
}
