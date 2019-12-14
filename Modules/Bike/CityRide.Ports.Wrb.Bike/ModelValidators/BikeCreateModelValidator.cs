using CityRide.Ports.Web.Bike.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Bike.ModelValidators
{
    public sealed class BikeCreateModelValidator
    {
        public class BikeModelValidator : AbstractValidator<BikeCreateModel>
        {
            private int _minLength = 3;
            private int _maxLength = 32;

            public BikeModelValidator()
            {
                RuleFor(x => x.Model).NotNull().Length(_minLength, _maxLength);
                RuleFor(x => x.IsActive).NotNull();
            }
        }
    }
}
