using AspnetRun.Services.Products.Application.Models.Base;

namespace AspnetRun.Services.Products.Application.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
