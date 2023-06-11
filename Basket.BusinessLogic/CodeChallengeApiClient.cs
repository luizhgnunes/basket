using Basket.Common.Interfaces;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Basket.BusinessLogic
{
    public class CodeChallengeApiClient : RestClient
    {
        public CodeChallengeApiClient(string apiEndpoint) : base(apiEndpoint, configureSerialization: s => s.UseNewtonsoftJson())
        {
            if (string.IsNullOrWhiteSpace(apiEndpoint))
                throw new ArgumentNullException(nameof(apiEndpoint));
        }

        public CodeChallengeApiClient(IConfigurationCache configurationCache) : this(configurationCache.Get<string>("CodeChallengeApiEndpointPrefix")) { }
    }
}
