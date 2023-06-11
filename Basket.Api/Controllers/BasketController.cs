using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketBusinessLogic _basketBusinessLogic;

        public BasketController(IBasketBusinessLogic basketBusinessLogic)
        {
            _basketBusinessLogic = basketBusinessLogic;
        }

        // GET api/basket
        [HttpGet]
        public async Task<ActionResult<Common.Models.Basket>> GetAll()
        {
            var baskets = await _basketBusinessLogic.GetAllBasketsAsync();
            return Ok(baskets);
        }

        // GET api/basket/11111111-1111-1111-1111-111111111111
        [HttpGet("{id}")]
        public async Task<ActionResult<Common.Models.Basket>> Get(Guid id)
        {
            var basket = await _basketBusinessLogic.GetBasketAsync(id);
            return Ok(basket);
        }

        // POST api/basket
        [HttpPost]
        public async Task<ActionResult<Common.Models.Basket>> PostCreateBasket(OrderRequest orderRequest)
        {
            var basket = await _basketBusinessLogic.CreateBasketAsync(orderRequest);
            return Ok(basket);
        }

        // PUT api/basket
        [HttpPut]
        public async Task<ActionResult<Common.Models.Basket>> PutUpdateBasket(Common.Models.Basket basket)
        {
            await _basketBusinessLogic.UpdateBasketAsync(basket);
            return Ok(basket);
        }

        // DELETE api/basket/11111111-1111-1111-1111-111111111111
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(Guid id)
        {
            var deleted = await _basketBusinessLogic.DeleteBasketAsync(id);
            if (!deleted)
                BadRequest($"Unable to delete the basket \"{id}\".");
            return Ok($"The basket \"{id}\" was deleted successfully.");
        }
    }
}
