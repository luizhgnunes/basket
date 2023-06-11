namespace Basket.Common.Interfaces
{
    public interface IConfigurationCache
    {
        T Get<T>(string key);
    }
}
