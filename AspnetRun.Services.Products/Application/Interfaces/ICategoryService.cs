using AspnetRun.Services.Products.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();
    }
}
