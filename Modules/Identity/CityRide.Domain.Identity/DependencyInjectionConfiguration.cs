using System.Text;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using CityRide.Domain.Identity.ApplicationServices.Implementations;
using CityRide.Domain.Identity.ApplicationServices.Interfaces;
using CityRide.Domain.Identity.DomainServices.Implementations;
using CityRide.Domain.Identity.DomainServices.Interfaces;

namespace CityRide.Domain.Identity
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterIdentityBusinessLogic(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<ICredentialsApplicationService, CredentialsApplicationService>();
            service.AddScoped<IAuthenticationApplicationService, AuthenticationApplicationService>();
            service.AddScoped<ICardApplicationService, CardApplicationService>();

            service.AddScoped<IPasswordHasher, PasswordHasher>();

            service
                .AddAuthentication()
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireSignedTokens = true,
                        ValidAudience = configuration["JwtOptions:Audience"],
                        ValidIssuer = configuration["JwtOptions:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:Key"])),
                    };
                });
        }
    }
}
