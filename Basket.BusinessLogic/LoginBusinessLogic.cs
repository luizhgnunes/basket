using Basket.Common.CodeChallengeApi;
using Basket.Common.Interfaces;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Models;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;

namespace Basket.BusinessLogic
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        private readonly CodeChallengeApiClient _client;
        private readonly IConfigurationCache _configurationCache;

        private string _token;

        public LoginBusinessLogic(CodeChallengeApiClient client, IConfigurationCache configurationCache)
        {
            _client = client;
            _configurationCache = configurationCache;
        }

        public async Task<string> GetTokenAsync(string email = null)
        {
            if (string.IsNullOrWhiteSpace(_token) || !CheckTokenIsValid(_token))
            {
                var userEmail = string.IsNullOrEmpty(email) ? _configurationCache.Get<string>("LoginDefaultUserEmail") : email;
                var loginRequestBody = new LoginRequest { Email = userEmail };
                var request = new RestRequest(Endpoints.LOGIN_ENDPOINT)
                    .AddJsonBody(loginRequestBody);
                var result = await _client.PostAsync<LoginResponse>(request);
                _token = result.Token;
            }

            return _token;
        }

        private static long GetTokenExpirationTime(string token)
        {
            var jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
            var ticks = long.Parse(tokenExp);
            return ticks;
        }

        private static bool CheckTokenIsValid(string token)
        {
            var tokenTicks = GetTokenExpirationTime(token);
            var tokenUtcDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

            return tokenUtcDate >= DateTime.Now.ToUniversalTime();
        }
    }
}
