using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;

namespace Basket.BusinessLogic
{
    public class OrderBusinessLogic : IOrderBusinessLogic
    {

        public OrderBusinessLogic()
        {
        }

        public Task<OrderResponse> CreateOrderAsync(Guid basketId)
        {
            throw new NotImplementedException();
        }
    }
}
