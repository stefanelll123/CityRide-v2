using AutoMapper;
using CityRide.Ports.Web.Bike.Models;

namespace CityRide.Adapters.Web.Bike
{
    public static class AutoMapperConfiguration
    {
        public static void AddBikeMappers(this IMapperConfigurationExpression config)
        {
            config.CreateMap<BikeModel, Entities.Bike.Bike>();
            config.CreateMap<Entities.Bike.Bike, BikeModel>();
        }
    }
}
