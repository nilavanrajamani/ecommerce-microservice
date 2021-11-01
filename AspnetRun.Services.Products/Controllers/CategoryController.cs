using AspnetRun.Services.Products.Application.Interfaces;
using AspnetRun.Services.Products.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);            
            return Ok(mapped);
        }
    }
}
