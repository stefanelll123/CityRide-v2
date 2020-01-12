using AutoMapper;

using CityRide.Entities.Identity.Dtos;
using CityRide.Ports.Web.Identity.Models;

namespace CityRide.Adapters.DataAccess.Bike
{
    public static class AutoMapperConfiguration
    {
        public static void AddInteropIdentityBikeMappers(this IMapperConfigurationExpression config)
        {
            config.CreateMap<CardModel, CardDto>();
        }
    }
}
