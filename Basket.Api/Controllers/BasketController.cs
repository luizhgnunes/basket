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

        /// <summary>
        /// Get all baskets.
        /// </summary>
        /// <returns>A list of <see cref="Common.Models.Basket"/></returns>
        // GET api/basket
        [HttpGet]
        public async Task<ActionResult<Common.Models.Basket>> GetAll()
        {
            var baskets = await _basketBusinessLogic.GetAllBasketsAsync();
            return Ok(baskets);
        }

        /// <summary>
        /// Get basket by id.
        /// </summary>
        /// <param name="id">Basket id.</param>
        /// <returns><see cref="Common.Models.Basket"/></returns>
        // GET api/basket/11111111-1111-1111-1111-111111111111
        [HttpGet("{id}")]
        public async Task<ActionResult<Common.Models.Basket>> Get(Guid id)
        {
            var basket = await _basketBusinessLogic.GetBasketAsync(id);
            return Ok(basket);
        }

        /// <summary>
        /// Cretate a basket.
        /// </summary>
        /// <param name="orderRequest"><see cref="OrderRequest"/></param>
        /// <returns></returns>
        // POST api/basket
        [HttpPost]
        public async Task<ActionResult<Common.Models.Basket>> PostCreateBasket(OrderRequest orderRequest)
        {
            var basket = await _basketBusinessLogic.CreateBasketAsync(orderRequest);
            return Ok(basket);
        }

        /// <summary>
        /// Update a basket.
        /// </summary>
        /// <param name="basket">The <see cref="Common.Models.Basket"/>.</param>
        /// <returns></returns>
        // PUT api/basket
        [HttpPut]
        public async Task<ActionResult<Common.Models.Basket>> PutUpdateBasket(Common.Models.Basket basket)
        {
            await _basketBusinessLogic.UpdateBasketAsync(basket);
            return Ok(basket);
        }

        /// <summary>
        /// Delete a basket by id.
        /// </summary>
        /// <param name="id">Basket id.</param>
        /// <returns>A message informing if the deletion occurred successfully or not.</returns>
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
