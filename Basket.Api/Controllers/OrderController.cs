using Basket.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        // POST api/order
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostCreateOrder(Guid basketId)
        {
            return null;
        }
    }
}
