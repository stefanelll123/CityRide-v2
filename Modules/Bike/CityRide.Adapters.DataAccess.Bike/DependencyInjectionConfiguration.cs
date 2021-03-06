﻿using CityRide.Adapters.DataAccess.Bike.Repositories;
using CityRide.Interop.DataAccess.Bike.Repositories;
using CityRide.Interop.Identity.Bike;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Adapters.DataAccess.Bike
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterBikeRepositories(this IServiceCollection service)
        {
            service.AddScoped<IBikeRepository, BikeRepository>();
            service.AddScoped<IBorrowRepository, BorrowRepository>();
            service.AddScoped<IPriceRepository, PriceRepository>();
            service.AddScoped<IIdentityInterop, IdentityInterop>();
        }
    }
}
