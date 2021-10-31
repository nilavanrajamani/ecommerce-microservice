using AspnetRun.Services.Products.ViewModels.Base;

namespace AspnetRun.Services.Products.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
    }
}
