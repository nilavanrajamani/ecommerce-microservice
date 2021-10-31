using AspnetRun.Services.Products.Application.Interfaces;
using AspnetRun.Services.Products.Application.Mapper;
using AspnetRun.Services.Products.Application.Models;
using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Interfaces;
using AspnetRun.Services.Products.Core.Repositories;
using AspnetRun.Services.Products.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Application.Services
{
    public class CompareService : ICompareService
    {
        private ICompareRepository _compareRepository;
        private IProductRepository _productRepository;
        private IAppLogger<CompareService> _logger;

        public CompareService(ICompareRepository compareRepository, IProductRepository productRepository, IAppLogger<CompareService> logger)
        {
            _compareRepository = compareRepository ?? throw new ArgumentNullException(nameof(compareRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddItem(string userName, int productId)
        {
            var compare = await GetExistingOrCreateNewCompare(userName);
            compare.AddItem(productId);
            await _compareRepository.UpdateAsync(compare);
        }

        private async Task<Compare> GetExistingOrCreateNewCompare(string userName)
        {
            var compare = await _compareRepository.GetByUserNameAsync(userName);
            if (compare != null)
                return compare;

            // if it is first attempt create new
            var newCompare = new Compare
            {
                UserName = userName
            };

            await _compareRepository.AddAsync(newCompare);
            return newCompare;
        }

        public async Task<CompareModel> GetCompareByUserName(string userName)
        {
            var compare = await GetExistingOrCreateNewCompare(userName);
            var compareModel = ObjectMapper.Mapper.Map<CompareModel>(compare);

            foreach (var item in compare.ProductCompares)
            {
                var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                compareModel.Items.Add(productModel);
            }
            return compareModel;
        }

        public async Task RemoveItem(int CompareId, int productId)
        {
            var spec = new CompareWithItemsSpecification(CompareId);
            var compare = (await _compareRepository.GetAsync(spec)).FirstOrDefault();
            compare.RemoveItem(productId);
            await _compareRepository.UpdateAsync(compare);
        }
    }
}
