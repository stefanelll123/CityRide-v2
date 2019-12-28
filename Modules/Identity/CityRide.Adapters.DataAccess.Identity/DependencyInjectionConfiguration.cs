using Microsoft.Extensions.DependencyInjection;

using CityRide.Adapters.DataAccess.Identity.Repositories;
using CityRide.Interop.DataAccess.Identity.Repositories;

namespace CityRide.Adapters.DataAccess.Identity
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterIdentityRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
