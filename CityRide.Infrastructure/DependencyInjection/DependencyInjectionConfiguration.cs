using CityRide.Infrastructure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterInfrastructure(this IServiceCollection service)
        {
            service.AddSingleton<DatabaseContext>();
            service.AddScoped<IBusManager, BusManager>();
        }
    }
}
