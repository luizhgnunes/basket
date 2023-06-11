using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Interfaces.Repository;
using Basket.Common.Models;

namespace Basket.BusinessLogic
{
    public class BasketBusinessLogic : IBasketBusinessLogic
    {
        private readonly IBasketRepository _basketRepository;

        public BasketBusinessLogic(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Task<Common.Models.Basket> CreateBasketAsync(OrderRequest orderRequest)
        {
            var basket = new Common.Models.Basket(Guid.NewGuid(), orderRequest);
            _basketRepository.Add(basket);
            return Task.FromResult(basket);
        }

        public Task<IEnumerable<Common.Models.Basket>> GetAllBasketsAsync()
        {
            return Task.FromResult(_basketRepository.GetAll());
        }

        public Task<Common.Models.Basket> GetBasketAsync(Guid basketId)
        {
            return Task.FromResult(_basketRepository.GetBasket(basketId));
        }

        public Task<Common.Models.Basket> UpdateBasketAsync(Common.Models.Basket basket)
        {
            return Task.FromResult(_basketRepository.UpdateBasket(basket));
        }

        public Task<bool> DeleteBasketAsync(Guid basketId)
        {
            return Task.FromResult(_basketRepository.Delete(basketId));
        }
    }
}