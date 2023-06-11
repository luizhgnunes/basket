using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;

namespace Basket.BusinessLogic
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {

        public ProductBusinessLogic()
        {
        }

        public Task<IEnumerable<ProductResponse>> GetProductCatalogAsync(int pageSize = 100, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetTopRankedProductsAsync(int totalProducts)
        {
            throw new NotImplementedException();
        }
    }
}
