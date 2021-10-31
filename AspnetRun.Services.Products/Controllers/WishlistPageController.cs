using AspnetRun.Services.Products.Application.Interfaces;
using AspnetRun.Services.Products.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Services.Products.Controllers
{
    [ApiController]
    [Route("api/wishlistpage")]
    public class WishlistPageController : Controller
    {
        private IWishlistService _wishListAppService;
        private IMapper _mapper;
        private ILogger<WishlistPageController> _logger;

        public WishlistPageController(IWishlistService wishListAppService, IMapper mapper, ILogger<WishlistPageController> logger)
        {
            _wishListAppService = wishListAppService ?? throw new ArgumentNullException(nameof(wishListAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlist(string userName)
        {
            var wishlist = await _wishListAppService.GetWishlistByUserName(userName);
            var mapped = _mapper.Map<WishlistViewModel>(wishlist);
            return Ok(mapped);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItem(int wishlistId, int productId)
        {
            await _wishListAppService.RemoveItem(wishlistId, productId);
            return Ok();
        }
    }
}
