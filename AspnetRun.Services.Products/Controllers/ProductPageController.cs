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
    [Route("api/productpage")]
    public class ProductPageController : Controller
    {
        private IProductService _productAppService;
        private IMapper _mapper;

        public ProductPageController(IProductService productAppService, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await _productAppService.GetProductList();
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return Ok(mapped);
        }
    }
}
