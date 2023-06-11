using Basket.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Basket.Common
{
    public class ConfigurationCache : IConfigurationCache
    {
        private readonly IConfiguration _configuration;

        public ConfigurationCache(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T Get<T>(string key)
        {
            return _configuration.GetSection(key).Get<T>();
        }
    }
}
