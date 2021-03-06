using FluentValidation;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;

namespace MoneyWatcher.Businness.Utils.FluentValidation
{
    public class LoginDtoValidation: AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(I => I.Email).NotEmpty().WithMessage("Email can not be empty");
            RuleFor(I => I.Email).NotNull().WithMessage("Email can not be null");
            RuleFor(I => I.Email).Length(1,150).WithMessage("More than {MinLength} , Less than {MaxLength} words");

            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(I => I.Password).NotNull().WithMessage("Password can not be null");
            RuleFor(I => I.Password).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");
        }
    }
}