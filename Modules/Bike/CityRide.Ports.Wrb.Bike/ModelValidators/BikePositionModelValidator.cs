using CityRide.Ports.Web.Bike.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Bike.ModelValidators
{
    public sealed class BikePositionModelValidator : AbstractValidator<BikeModel>
    {
        public BikePositionModelValidator()
        {
            RuleFor(x => x.Latitude).NotEmpty();
            RuleFor(x => x.Longitude).NotEmpty();
        }
    }
}
