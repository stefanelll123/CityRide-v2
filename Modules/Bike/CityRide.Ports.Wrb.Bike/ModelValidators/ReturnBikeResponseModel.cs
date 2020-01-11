using CityRide.Ports.Web.Bike.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Bike.ModelValidators
{
    public class ReturnBikeResponseModelValidator : AbstractValidator<ReturnBikeResponseModel>
    {
        public ReturnBikeResponseModelValidator()
        {
            RuleFor(x => x.Hours).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
