using CityRide.Ports.Web.Bike;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Adapters.Web.Bike
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterWebAdapters(this IServiceCollection service)
        {
            service.AddScoped<IBikePort, BikePort>();
        }
    }
}
