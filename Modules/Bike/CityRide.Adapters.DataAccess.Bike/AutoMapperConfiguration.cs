using AutoMapper;

using CityRide.Entities.Bike.Dtos;
using CityRide.Ports.Web.Identity;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.DataAccess.Bike
{
    public static class AutoMapperConfiguration
    {
        public static void AddInteropIdentityBikeMappers(this IMapperConfigurationExpression config)
        {
            config.CreateMap<CardModel, CardDto>();
            config.CreateMap<UserModel, UserDto>();
        }
    }
}
