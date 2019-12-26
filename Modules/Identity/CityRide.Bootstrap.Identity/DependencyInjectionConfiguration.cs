using Microsoft.Extensions.DependencyInjection;

using CityRide.Adapters.DataAccess.Identity;
using CityRide.Adapters.Web.Identity;
using CityRide.Domain.Identity;

namespace CityRide.Bootstrap.Identity
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterIdentityModule(this IServiceCollection service)
        {
            service.RegisterIdentityRepositories();
            service.RegisterIdentityBusinessLogic();
            service.RegisterIdentityAdapters();
        }
    }
}
