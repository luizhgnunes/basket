using Basket.Common.Interfaces.BusinessLogic;

namespace Basket.BusinessLogic
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {

        public LoginBusinessLogic() 
        {
        }

        public Task<string> GetTokenAsync(string email = null)
        {
            throw new NotImplementedException();
        }
    }
}
