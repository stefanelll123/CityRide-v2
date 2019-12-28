using CityRide.Ports.Web.Identity.Models;
using FluentValidation;

namespace CityRide.Ports.Web.Identity.ModelValidators
{
    public class UserAuthentificationModelValidator : AbstractValidator<CreateUserModel>
    {
        private readonly int nameMinLength = 5;
        private readonly int passwordMinLength = 12;

        public UserAuthentificationModelValidator()
        {
            RuleFor(x => x.FullName)
                .NotNull()
                .MinimumLength(nameMinLength);
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(passwordMinLength);
        }
    }
}
