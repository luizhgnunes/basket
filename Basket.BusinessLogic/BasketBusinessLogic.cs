using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;

namespace Basket.BusinessLogic
{
    public class BasketBusinessLogic : IBasketBusinessLogic
    {

        public BasketBusinessLogic() 
        {

        }

        public Task<Common.Models.Basket> CreateBasketAsync(OrderRequest orderRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBasketAsync(Guid basketId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Common.Models.Basket>> GetAllBasketsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Common.Models.Basket> GetBasketAsync(Guid basketId)
        {
            throw new NotImplementedException();
        }

        public Task<Common.Models.Basket> UpdateBasketAsync(Common.Models.Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}