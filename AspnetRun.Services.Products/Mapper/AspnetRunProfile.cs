using AspnetRun.Services.Products.Application.Models;
using AspnetRun.Services.Products.ViewModels;
using AutoMapper;

namespace AspnetRun.Services.Products
{
    public class AspnetRunProfile : Profile
    {
        public AspnetRunProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();            
        }
    }
}
