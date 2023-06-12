using Basket.Common.Interfaces;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        private readonly int _topRankedProductsSize;

        public ProductController(IConfigurationCache configurationCache, IProductBusinessLogic productBusinessLogic)
        {
            _productBusinessLogic = productBusinessLogic;
            _topRankedProductsSize = configurationCache.Get<int>("Pagination:TopRankedProductsSize");
        }

        /// <summary>
        /// Get top ranked products. 
        /// The amount of products returned must be set up on the file "appsettings.json", on the property "Pagination:TopRankedProductsSize".
        /// </summary>
        /// <returns>An enumerable of <see cref="ProductResponse"/></returns>
        // GET: api/product/top-ranked
        [HttpGet("top-ranked")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetTopRankedProducts()
        {
            var result = await _productBusinessLogic.GetTopRankedProductsAsync(_topRankedProductsSize);
            return Ok(result);
        }

        /// <summary>
        /// Return a paginated result of the product catalog ordered by price in ascending order and properly paginated.
        /// It should not allow page size above 1000 (value set up on the file "appsettings.json", on the property "Pagination:MaxPageSize").
        /// </summary>
        /// <param name="pageSize">
        /// The page size. 
        /// The max value must be less than or equal to 1000 (value set up on the file "appsettings.json", on the property "Pagination:MaxPageSize").
        /// </param>
        /// <param name="pageNumber">Page number.</param>
        /// <returns>An enumerable of <see cref="ProductResponse"/>.</returns>
        // GET api/product/catalog/page-size/100/page-number/1
        [HttpGet("catalog/page-size/{pageSize}/page-number/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductCatalog(int pageSize = 100, int pageNumber = 1)
        {
            var result = await _productBusinessLogic.GetProductCatalogAsync(pageSize, pageNumber);
            return Ok(result);
        }

        /// <summary>
        /// Get the 10 cheapest products from all the products.
        /// </summary>
        /// <returns>An enumerable of <see cref="ProductResponse"/>.</returns>
        // GET api/product/cheapest
        [HttpGet("cheapest")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetCheapestProducts()
        {
            var result = await _productBusinessLogic.GetProductCatalogAsync(10);
            return Ok(result);
        }
    }
}
