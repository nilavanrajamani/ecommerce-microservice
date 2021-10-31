using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Specifications.Base;

namespace AspnetRun.Services.Products.Core.Specification
{
    public class ProductSlugSpecification : BaseSpecification<Product>
    {
        public ProductSlugSpecification(string slug)
            : base(p => p.Slug.ToLower().Contains(slug.ToLower()))
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Specifications);
            AddInclude(p => p.Reviews);
            AddInclude(p => p.Tags);
        }
    }
}
