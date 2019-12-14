using CityRide.Ports.Web.Bike.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Bike.ModelValidators
{
    public sealed class BikeModelValidator : AbstractValidator<BikeModel>
    {
        private readonly int minLength = 3;
        private readonly int maxLength = 32;

        public BikeModelValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Model).NotNull().Length(minLength, maxLength);
            RuleFor(x => x.IsActive).NotNull();
        }
    }
}
