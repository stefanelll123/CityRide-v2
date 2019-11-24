using CityRide.Business.Bikes.ApplicationSerivces.Implementations;
using CityRide.Business.Bikes.ApplicationSerivces.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Infrastructure.DependencyInjection
{
    public static class ServiceModule 
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBikeApplicationService, BikeApplicationService>();
        }
    }
}
