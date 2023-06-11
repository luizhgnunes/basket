namespace Basket.Common.Interfaces.BusinessLogic
{
    public interface ILoginBusinessLogic
    {
        Task<string> GetTokenAsync(string email = null);
    }
}
