using Basket.Common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        public BasketController()
        {
        }

        // GET api/basket
        [HttpGet]
        public async Task<ActionResult<Common.Models.Basket>> GetAll()
        {
            return null;
        }

        // GET api/basket/11111111-1111-1111-1111-111111111111
        [HttpGet("{id}")]
        public async Task<ActionResult<Common.Models.Basket>> Get(Guid id)
        {
            return null;
        }

        // POST api/basket
        [HttpPost]
        public async Task<ActionResult<Common.Models.Basket>> PostCreateBasket(OrderRequest orderRequest)
        {
            return null;
        }

        // PUT api/basket
        [HttpPut]
        public async Task<ActionResult<Common.Models.Basket>> PutUpdateBasket(Common.Models.Basket basket)
        {
            return null;
        }

        // DELETE api/basket/11111111-1111-1111-1111-111111111111
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            return null;
        }
    }
}
