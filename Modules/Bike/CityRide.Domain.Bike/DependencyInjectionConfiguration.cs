using CityRide.Domain.Bike.ApplicationServices.Implementations;
using CityRide.Domain.Bike.ApplicationServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Domain.Bike
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterBikeBusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<IBikeApplicationService, BikeApplicationService>();
            service.AddScoped<IBorrowApplicationService, BorrowApplicationService>();
        }
    }
}
