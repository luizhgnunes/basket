using Basket.Common.Models;

namespace Basket.Common.Interfaces.BusinessLogic
{
    public interface IProductBusinessLogic
    {
        Task<ProductResponse> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductResponse>> GetTopRankedProductsAsync(int totalProducts);
        Task<IEnumerable<ProductResponse>> GetProductCatalogAsync(int pageSize = 100, int pageNumber = 1);
    }
}
