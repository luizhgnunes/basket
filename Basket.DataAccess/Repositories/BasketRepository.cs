using Basket.Common.Interfaces.Repository;
using Basket.Common.Models;
using Basket.DataAccess.Data;

namespace Basket.DataAccess.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public bool Add(Common.Models.Basket basket)
        {
            return Database.Basket.TryAdd(basket.Id, basket.OrderRequest);
        }

        public IEnumerable<Common.Models.Basket> GetAll()
        {
            return Database.Basket.Select(b =>
            {
                return new Common.Models.Basket
                {
                    Id = b.Key,
                    OrderRequest = new OrderRequest
                    {
                        UserEmail = b.Value.UserEmail,
                        OrderLines = b.Value.OrderLines
                    }
                };
            });
        }

        public bool CheckIfBasketExists(Guid basketId)
        {
            return Database.Basket.Any(b => b.Key.Equals(basketId));
        }

        public Common.Models.Basket GetBasket(Guid basketId)
        {
            return new Common.Models.Basket(basketId, Database.Basket[basketId]);
        }

        public Common.Models.Basket UpdateBasket(Common.Models.Basket basket)
        {
            Database.Basket[basket.Id] = basket.OrderRequest;
            return basket;
        }

        public bool Delete(Guid basketId)
        {
            return Database.Basket.Remove(basketId, out _);
        }
    }
}
