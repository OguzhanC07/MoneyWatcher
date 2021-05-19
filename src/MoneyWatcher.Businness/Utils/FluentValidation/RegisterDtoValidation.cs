using FluentValidation;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;

namespace MoneyWatcher.Businness.Utils.FluentValidation
{
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can NOT be EMPTY");
            RuleFor(I => I.Password).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");
            RuleFor(I => I.Password).NotNull();


            RuleFor(I => I.Email).NotEmpty().WithMessage("Email can NOT be EMPTY");
            RuleFor(I => I.Email).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");
            RuleFor(I => I.Email).EmailAddress();



            RuleFor(I => I.FullName).NotEmpty().WithMessage("Name can NOT be EMPTY");
            RuleFor(I => I.FullName).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");
        }
    }
}