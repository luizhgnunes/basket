using Basket.Common.CustomExceptions;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Interfaces.Repository;
using Basket.Common.Models;

namespace Basket.BusinessLogic
{
    public class BasketBusinessLogic : IBasketBusinessLogic
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductBusinessLogic _productBusinessLogic;

        public BasketBusinessLogic(IBasketRepository basketRepository, IProductBusinessLogic productBusinessLogic)
        {
            _basketRepository = basketRepository;
            _productBusinessLogic = productBusinessLogic;
        }

        public async Task<Common.Models.Basket> CreateBasketAsync(BasketRequest basketRequest)
        {
            if (basketRequest.Products.Any(p => p.productId <= 0))
                throw new CustomHttpException("Product id is required.", System.Net.HttpStatusCode.BadRequest);
            if (basketRequest.Products.Any(p => p.quantity <= 0))
                throw new CustomHttpException("The quantity must be greater than 0.", System.Net.HttpStatusCode.BadRequest);

            var basket = new Common.Models.Basket();
            basket.OrderRequest.UserEmail = basketRequest.UserEmail;

            foreach (var p in basketRequest.Products)
            {
                var product = await _productBusinessLogic.GetProductByIdAsync(p.productId);
                if (product == null)
                    throw new CustomHttpException($"Product with the id {p.productId} was not found.", System.Net.HttpStatusCode.NotFound);
                var orderLine = new OrderLine
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductUnitPrice = product.Price,
                    ProductSize = product.Size.ToString(),
                    Quantity = p.quantity
                };
                basket.OrderRequest.OrderLines.Add(orderLine);
            }

            _basketRepository.Add(basket);
            return await Task.FromResult(basket);
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