using AutoMapper;

using CityRide.Entities.Identity;
using CityRide.Entities.Identity.Dtos;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.Web.Identity
{
    public static class AutoMapperConfiguration
    {
        public static void AddIdentityMappers(this IMapperConfigurationExpression config)
        {
            config.CreateMap<CreateUserModel, User>();
            config.CreateMap<UserAuthenticationModel, UserAuthenticationDto>();
            config.CreateMap<AuthenticationDto, AuthenticationModel>();
        }
    }
}
