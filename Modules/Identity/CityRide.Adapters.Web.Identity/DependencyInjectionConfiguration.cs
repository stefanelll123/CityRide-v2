﻿using CityRide.Adapters.Web.Identity.Ports;
using CityRide.Ports.Web.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Adapters.Web.Identity
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterIdentityAdapters(this IServiceCollection service)
        {
            service.AddScoped<IRegisterPort, RegisterPort>();
            service.AddScoped<IAuthenticationPort, AuthenticationPort>();
            service.AddScoped<ICardPort, CardPort>();
            service.AddScoped<IUserPort, UserPort>();
        }
    }
}
