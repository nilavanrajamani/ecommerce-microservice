using AspnetRun.Services.Basket.Core.Entities;
using AspnetRun.Services.Basket.Core.Specifications.Base;

namespace AspnetRun.Services.Basket.Core.Specifications
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(string productName) 
            : base(p => p.Name.ToLower().Contains(productName.ToLower()))
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification(int productId)
            : base(p => p.Id == productId)
        {
            AddInclude(p => p.Category);
        }

        public ProductWithCategorySpecification()
            : base(null)
        {
            AddInclude(p => p.Category);
        }
    }
}
