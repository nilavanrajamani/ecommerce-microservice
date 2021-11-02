using AspnetRun.Services.Basket.Application.Interfaces;
using AspnetRun.Services.Basket.ViewModel;
using AspnetRun.Services.ViewModels.Payload;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        private ICartService _cartAppService;
        private IMapper _mapper;
        private ILogger<CartController> _logger;

        public CartController(ICartService cartAppService, IMapper mapper, ILogger<CartController> logger)
        {
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(string userName)
        {
            var cart = await _cartAppService.GetCartByUserName(userName);
            var mapped = _mapper.Map<CartViewModel>(cart);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(CartItem cartItem)
        {            
            await _cartAppService.AddItem(cartItem.UserName, cartItem.ProductId);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItem(int cartId, int cartItemId)
        {
            await _cartAppService.RemoveItem(cartId, cartItemId);
            return Ok();
        }
    }
}
