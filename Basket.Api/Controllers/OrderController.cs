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

        /// <summary>
        /// Create a order related to the <see cref="Common.Models.Basket"/> passed in.
        /// It will call the Code Challenge API.
        /// </summary>
        /// <param name="basketId">The basket id.</param>
        /// <returns><see cref="OrderResponse"/></returns>
        // POST api/order
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostCreateOrder(Guid basketId)
        {
            var result = await _orderBusinessLogic.CreateOrderAsync(basketId);
            return Ok(result);
        }
    }
}
