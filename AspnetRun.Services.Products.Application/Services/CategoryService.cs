using AspnetRun.Services.Products.Application.Interfaces;
using AspnetRun.Services.Products.Application.Mapper;
using AspnetRun.Services.Products.Application.Models;
using AspnetRun.Services.Products.Core.Interfaces;
using AspnetRun.Services.Products.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IAppLogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, IAppLogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var category = await _categoryRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(category);
            return mapped;
        }
    }
}
