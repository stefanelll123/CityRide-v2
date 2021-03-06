﻿using AutoMapper;

using CityRide.Entities.Identity;
using CityRide.Entities.Identity.Dtos;
using CityRide.Ports.Web.Identity;
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

            config.CreateMap<Card, CardCreateModel>();
            config.CreateMap<CardCreateModel, Card>();

            config.CreateMap<Card, CardModel>()
                .ForMember(dest => dest.EndCardNumber, opt => opt.MapFrom(src => src.CardNumber.Substring(src.CardNumber.Length - 4)))

                .ForAllOtherMembers(x => x.Ignore());

            config.CreateMap<User, UserModel>();
            config.CreateMap<UserModel, User>();
        }
    }
}
