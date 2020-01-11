using CityRide.Entities.Bike.Dtos;
using CityRide.Ports.Web.Bike.Models;

using AutoMapper;

namespace CityRide.Adapters.Web.Bike
{
    public static class AutoMapperConfiguration
    {
        public static void AddBikeMappers(this IMapperConfigurationExpression config)
        {
            config.CreateMap<BikeModel, Entities.Bike.Bike>();
            config.CreateMap<Entities.Bike.Bike, BikeModel>();

            config.CreateMap<BikeCreateModel, Entities.Bike.Bike>();
            config.CreateMap<Entities.Bike.Bike, BikeCreateModel>();

            config.CreateMap<BikePositionDto, BikePositionModel>();
            config.CreateMap<BikePositionModel, BikePositionDto>();

            config.CreateMap<UserBorrowModel, UserBorrowDto>();
            config.CreateMap<UserBorrowDto, UserBorrowModel>();
        }
    }
}
