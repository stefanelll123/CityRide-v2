﻿using AutoMapper;
using CityRide.Adapters.DataAccess.Bike;
using CityRide.Adapters.Web.Bike;

namespace CityRide.Bootstrap.Bike
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterBikeModuleProfiler(this IMapperConfigurationExpression config)
        {
            config.AddBikeMappers();
            config.AddInteropIdentityBikeMappers();
        }
    }
}
