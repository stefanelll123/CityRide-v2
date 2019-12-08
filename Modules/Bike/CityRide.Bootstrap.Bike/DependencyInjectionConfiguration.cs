using CityRide.Adapters.DataAccess.Bike;
using CityRide.Adapters.Web.Bike;
using CityRide.Domain.Bike;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Bootstrap.Bike
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterBikeModule(this IServiceCollection service)
        {
            service.RegisterBikeRepositories();
            service.RegisterBikeBusinessLogic();
            service.RegisterWebAdapters();
        }
    }
}
