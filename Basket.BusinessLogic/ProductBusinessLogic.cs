using Basket.Common.CodeChallengeApi;
using Basket.Common.CustomExceptions;
using Basket.Common.Interfaces;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;
using RestSharp;

namespace Basket.BusinessLogic
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly CodeChallengeApiClient _client;
        private readonly IConfigurationCache _configurationCache;
        private readonly ILoginBusinessLogic _loginBusinessLogic;

        public ProductBusinessLogic(CodeChallengeApiClient client, IConfigurationCache configurationCache, ILoginBusinessLogic loginBusinessLogic)
        {
            _client = client;
            _configurationCache = configurationCache;
            _loginBusinessLogic = loginBusinessLogic;
        }

        public async Task<ProductResponse> GetProductByIdAsync(int productId)
        {
            var token = await _loginBusinessLogic.GetTokenAsync();
            var request = new RestRequest(Endpoints.GET_ALL_PRODUCTS_ENDPOINT)
                .AddHeader("Authorization", $"Bearer {token}");
            var products = await _client.GetAsync<IEnumerable<ProductResponse>>(request);
            return products.FirstOrDefault(p => p.Id == productId);
        }

        public async Task<IEnumerable<ProductResponse>> GetTopRankedProductsAsync(int totalProducts)
        {
            var token = await _loginBusinessLogic.GetTokenAsync();
            var request = new RestRequest(Endpoints.GET_ALL_PRODUCTS_ENDPOINT)
                .AddHeader("Authorization", $"Bearer {token}");
            var products = await _client.GetAsync<IEnumerable<ProductResponse>>(request);
            return products.OrderByDescending(p => p.Stars).ThenBy(p => p.Id).Take(totalProducts);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductCatalogAsync(int pageSize = 100, int pageNumber = 1)
        {
            var maxPageSize = _configurationCache.Get<int>("Pagination:MaxPageSize");
            if (pageSize > maxPageSize)
                throw new CustomHttpException($"The page size must be less than or equal to {maxPageSize}.", System.Net.HttpStatusCode.BadRequest);
            var token = await _loginBusinessLogic.GetTokenAsync();
            var request = new RestRequest(Endpoints.GET_ALL_PRODUCTS_ENDPOINT)
                .AddHeader("Authorization", $"Bearer {token}");
            var products = await _client.GetAsync<IEnumerable<ProductResponse>>(request);
            return products.OrderBy(p => p.Price).Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        }
    }
}
