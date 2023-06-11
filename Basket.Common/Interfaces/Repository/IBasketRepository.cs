namespace Basket.Common.Interfaces.Repository
{
    public interface IBasketRepository
    {
        bool Add(Models.Basket basket);
        IEnumerable<Models.Basket> GetAll();
        bool CheckIfBasketExists(Guid basketId);
        Models.Basket GetBasket(Guid basketId);
        Models.Basket UpdateBasket(Models.Basket basket);
        bool Delete(Guid basketId);
    }
}
