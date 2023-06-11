using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusinessLogic _orderBusinessLogic;

        public OrderController(IOrderBusinessLogic orderBusinessLogic)
        {
            _orderBusinessLogic = orderBusinessLogic;
        }

        // POST api/order
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostCreateOrder(Guid basketId)
        {
            var result = await _orderBusinessLogic.CreateOrderAsync(basketId);
            return Ok(result);
        }
    }
}
