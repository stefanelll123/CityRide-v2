using CityRide.Business.Repositories;
using CityRide.Data.Context;
using CityRide.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Infrastructure.DependencyInjection
{
    public static class RepositoryModule
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseContext>();
            services.AddScoped<IBikeRepository, BikeRepository>();
        }
    }
}
