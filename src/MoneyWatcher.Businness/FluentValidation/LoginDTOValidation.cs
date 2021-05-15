using FluentValidation;
using MoneyWatcher.Businness.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.FluentValidation
{
    public class LoginDTOValidation: AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation()
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
