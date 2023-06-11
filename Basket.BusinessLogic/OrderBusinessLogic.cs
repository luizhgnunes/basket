using Basket.Common.CodeChallengeApi;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;
using RestSharp;

namespace Basket.BusinessLogic
{
    public class OrderBusinessLogic : IOrderBusinessLogic
    {
        private readonly CodeChallengeApiClient _client;
        private readonly ILoginBusinessLogic _loginBusinessLogic;
        private readonly IBasketBusinessLogic _basketBusinessLogic;

        public OrderBusinessLogic(CodeChallengeApiClient client, ILoginBusinessLogic loginBusinessLogic, IBasketBusinessLogic basketBusinessLogic)
        {
            _client = client;
            _loginBusinessLogic = loginBusinessLogic;
            _basketBusinessLogic = basketBusinessLogic;
        }

        public async Task<OrderResponse> CreateOrderAsync(Guid basketId)
        {
            var basket = await _basketBusinessLogic.GetBasketAsync(basketId);
            var token = await _loginBusinessLogic.GetTokenAsync();
            var request = new RestRequest(Endpoints.CREATE_ORDER_ENDPOINT)
                .AddHeader("Authorization", $"Bearer {token}")
                .AddJsonBody(basket.OrderRequest);
            return await _client.PostAsync<OrderResponse>(request);
        }
    }
}
