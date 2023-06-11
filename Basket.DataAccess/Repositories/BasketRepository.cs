using Basket.Common.Interfaces.Repository;

namespace Basket.DataAccess.Repositories
{
    internal class BasketRepository : IBasketRepository
    {
        public bool Add(Common.Models.Basket basket)
        {
            return true;
        }

        public IEnumerable<Common.Models.Basket> GetAll()
        {
            return null;
        }

        public bool CheckIfBasketExists(Guid basketId)
        {
            return true;
        }

        public Common.Models.Basket GetBasket(Guid basketId)
        {
            return null;
        }

        public Common.Models.Basket UpdateBasket(Common.Models.Basket basket)
        {
            return null;
        }

        public bool Delete(Guid basketId)
        {
            return true;
        }
    }
}
