using AutoMapper;
using CityRide.Adapters.Web.Identity;

namespace CityRide.Bootstrap.Identity
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterIdentityModuleProfiler(this IMapperConfigurationExpression config)
        {
            config.AddIdentityMappers();
        }
    }
}
