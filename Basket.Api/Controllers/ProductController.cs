using Basket.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        // GET: api/product/top-ranked
        [HttpGet("top-ranked")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetTopRankedProducts()
        {
            return null;
        }

        // GET api/product/catalog/100/1
        [HttpGet("catalog/{pageSize}/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProductCatalog(int pageSize = 100, int pageNumber = 1)
        {
            return null;
        }

        // GET api/product/cheapest
        [HttpGet("cheapest")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetCheapestProducts()
        {
            return null;
        }

    }
}
