using Basket.Common.Models;

namespace Basket.Common.Interfaces.BusinessLogic
{
    public interface IOrderBusinessLogic
    {
        Task<OrderResponse> CreateOrderAsync(Guid basketId);
    }
}
