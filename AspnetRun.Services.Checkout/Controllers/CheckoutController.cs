using AspnetRun.Services.Basket.Application.Interfaces;
using AspnetRun.Services.Basket.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Services.Basket.Controllers
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : Controller
    {
        private ICartService _cartAppService;
        private IMapper _mapper;
        private ILogger<CheckoutController> _logger;

        public CheckoutController(ICartService cartAppService, IMapper mapper, ILogger<CheckoutController> logger)
        {
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public async Task CheckOut(OrderViewModel order, string userName)
        {
            //Get cart
            //var cart = await GetCart(userName);
            //TransformCartItemToOrderItem(order, cart);
            //SetUserNameOfOrder(order, userName);

            //var mappedOrderModel = _mapper.Map<OrderModel>(order);
            //await _orderAppService.CheckOut(mappedOrderModel);

            await _cartAppService.ClearCart(userName);
        }

        private void TransformCartItemToOrderItem(OrderViewModel order, CartViewModel cart)
        {
            foreach (var cartItem in cart.Items)
            {
                order.Items.Add(
                    new OrderItemView
                    {
                        Color = cartItem.Color,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.UnitPrice,
                        TotalPrice = cartItem.TotalPrice,
                        ProductId = cartItem.ProductId,
                        Product = cartItem.Product
                    });
            }
        }

        private void SetUserNameOfOrder(OrderViewModel order, string userName)
        {
            order.UserName = userName;
        }

    }
}
