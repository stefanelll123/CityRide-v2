using CityRide.Business.Bikes.Models;
using CityRide.CrossCuttingConcern;
using CityRide.Domain.Entities;
using CityRide.Infrastructure.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Infrastructure.DependencyInjection
{
    public static class MapperModule
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<BikeModel, Bike>();
                cfg.CreateMap<Bike, BikeModel>();
            });

            services.AddSingleton(typeof(AutoMapper.IMapper), config.CreateMapper());
            services.AddScoped<IMapper, Mapper>();
        }
    }
}
