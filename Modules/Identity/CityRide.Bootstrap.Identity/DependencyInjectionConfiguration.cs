using Microsoft.Extensions.DependencyInjection;

using CityRide.Adapters.DataAccess.Identity;
using CityRide.Adapters.Web.Identity;
using CityRide.Domain.Identity;
using Microsoft.Extensions.Configuration;

namespace CityRide.Bootstrap.Identity
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterIdentityModule(this IServiceCollection service, IConfiguration configuration)
        {
            service.RegisterIdentityRepositories();
            service.RegisterIdentityBusinessLogic(configuration);
            service.RegisterIdentityAdapters();
        }
    }
}
