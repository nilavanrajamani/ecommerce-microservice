using AspnetRun.Services.Basket.Core.Entities;
using AspnetRun.Services.Basket.Core.Specifications.Base;

namespace AspnetRun.Services.Basket.Core.Specifications
{
    public class CartWithItemsSpecification : BaseSpecification<Cart>
    {
        public CartWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.Items);
        }

        public CartWithItemsSpecification(int cartId)
            : base(p => p.Id == cartId)
        {
            AddInclude(p => p.Items);
        }
    }   
}
