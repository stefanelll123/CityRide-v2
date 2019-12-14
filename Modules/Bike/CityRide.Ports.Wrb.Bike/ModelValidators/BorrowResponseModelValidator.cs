using CityRide.Ports.Web.Bike.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Bike.ModelValidators
{
    public class BorrowResponseModelValidator : AbstractValidator<BorrowResponseModel>
    {
        public BorrowResponseModelValidator()
        {
            RuleFor(x => x.Borrowable).NotNull();
            RuleFor(x => x.Found).NotNull();
        }
    }
}
