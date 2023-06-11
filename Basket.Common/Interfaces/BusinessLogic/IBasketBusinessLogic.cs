using Basket.Common.Models;

namespace Basket.Common.Interfaces.BusinessLogic
{
    public interface IBasketBusinessLogic
    {
        Task<Models.Basket> CreateBasketAsync(OrderRequest orderRequest);
        Task<IEnumerable<Models.Basket>> GetAllBasketsAsync();
        Task<Models.Basket> GetBasketAsync(Guid basketId);
        Task<Models.Basket> UpdateBasketAsync(Models.Basket basket);
        Task<bool> DeleteBasketAsync(Guid basketId);
    }
}
