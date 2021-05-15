using FluentValidation;
using MoneyWatcher.Businness.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.FluentValidation
{
    public class RegisterDTOValidation :AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidation()
        {
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password can NOT be EMPTY");
            RuleFor(I => I.Password).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");



            RuleFor(I => I.Email).NotEmpty().WithMessage("Email can NOT be EMPTY");
            RuleFor(I => I.Email).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");
            RuleFor(I => I.Email).EmailAddress();



            RuleFor(I => I.FullName).NotEmpty().WithMessage("Name can NOT be EMPTY");
            RuleFor(I => I.FullName).Length(1, 150).WithMessage("More than {MinLength} , Less than {MaxLength} words");

        }
    }
}
