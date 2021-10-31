using AspnetRun.Services.Products.Core.Entities;
using AspnetRun.Services.Products.Core.Specifications.Base;

namespace AspnetRun.Services.Products.Core.Specification
{
    public class WishlistWithItemsSpecification : BaseSpecification<Wishlist>
    {
        public WishlistWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.ProductWishlists);
        }

        public WishlistWithItemsSpecification(int wishlistId)
            : base(p => p.Id == wishlistId)
        {
            AddInclude(p => p.ProductWishlists);
        }
    }
}
