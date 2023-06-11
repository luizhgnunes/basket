using Basket.BusinessLogic;
using Basket.Common.Interfaces.BusinessLogic;
using Basket.Common.Interfaces.Repository;
using Basket.DataAccess.Repositories;

namespace Basket.Api.Bootstrappers
{
    internal static class DependencyInjectionBootstrapper
    {
        internal static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ILoginBusinessLogic, LoginBusinessLogic>();
            services.AddSingleton<IBasketBusinessLogic, BasketBusinessLogic>();
            services.AddSingleton<IProductBusinessLogic, ProductBusinessLogic>();
            services.AddSingleton<IOrderBusinessLogic, OrderBusinessLogic>();

            services.AddSingleton<IBasketRepository, BasketRepository>();
        }
    }
}
