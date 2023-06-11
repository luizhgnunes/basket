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

        // GET: api/product/top-ranked
        [HttpGet("top-ranked")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetTopRankedProducts()
        {
            var result = await _productBusinessLogic.GetTopRankedProductsAsync(_topRankedProductsSize);
            return Ok(result);
        }

        // GET api/product/catalog/page-size/100/page-number/1
        [HttpGet("catalog/page-size/{pageSize}/page-number/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductCatalog(int pageSize = 100, int pageNumber = 1)
        {
            var result = await _productBusinessLogic.GetProductCatalogAsync(pageSize, pageNumber);
            return Ok(result);
        }

        // GET api/product/cheapest
        [HttpGet("cheapest")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetCheapestProducts()
        {
            var result = await _productBusinessLogic.GetProductCatalogAsync(10);
            return Ok(result);
        }
    }
}
