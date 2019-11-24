using CityRide.Business.Bikes.Models;
using CityRide.Business.Bikes.ModelValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CityRide.Infrastructure.Configurations
{
    public static class ModelValidationRegistry
    {
        public static void RegisterModelValidations(this IServiceCollection services)
        {
            services.AddTransient<IValidator<BikeModel>, BikeModelValidator>();
        }
    }
}
