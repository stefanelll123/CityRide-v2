using CityRide.Domain.Identity.ApplicationServices.Implementations;
using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Domain.Identity
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterIdentityBusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<ICredentialsApplicationService, CredentialsApplicationService>();
        }
    }
}
