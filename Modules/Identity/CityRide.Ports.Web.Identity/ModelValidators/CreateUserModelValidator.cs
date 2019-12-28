using CityRide.Ports.Web.Identity.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Identity.ModelValidators
{
    public class CreateUserModelValidator : AbstractValidator<UserAuthenticationModel>
    {
        private readonly int passwordMinLength = 12;

        public CreateUserModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(passwordMinLength);
        }
    }
}
