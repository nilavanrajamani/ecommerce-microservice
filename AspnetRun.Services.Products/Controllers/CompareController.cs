using AspnetRun.Services.Products.Application.Interfaces;
using AspnetRun.Services.Products.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Controllers
{
    [ApiController]
    [Route("api/compare")]
    public class CompareController : Controller
    {
        private ICompareService _compareService;
        private IMapper _mapper;
        private ILogger<CompareController> _logger;

        public CompareController(ICompareService compareService, IMapper mapper, ILogger<CompareController> logger)
        {
            _compareService = compareService ?? throw new ArgumentNullException(nameof(compareService));            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetCompare(string userName)
        {
            var compare = await _compareService.GetCompareByUserName(userName);
            var mapped = _mapper.Map<CompareViewModel>(compare);
            return Ok(mapped);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItem(int compareId, int productId)
        {
            await _compareService.RemoveItem(compareId, productId);
            return Ok();
        }
    }
}
