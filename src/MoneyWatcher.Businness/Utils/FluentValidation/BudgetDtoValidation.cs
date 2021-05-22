using FluentValidation;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;

namespace MoneyWatcher.Businness.Utils.FluentValidation
{
    public class BudgetDtoValidation : AbstractValidator<BudgetAddDto>
    {
        public BudgetDtoValidation()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name required");
            RuleFor(I => I.Name).Length(1, 50)
                .WithMessage("Name at least must be {MinLength} or maximum {MaxLength} long");
            
            RuleFor(I => I.Detail).NotEmpty().WithMessage("Detail required");
            RuleFor(I => I.Detail).Length(1, 50)
                .WithMessage("Detail at least must be {MinLength} or maximum {MaxLength} long");

            RuleFor(I => I.Price).NotEmpty().WithMessage("Price must be not empty");
            RuleFor(I => I.BudgetType).NotEmpty().WithMessage("BudgetType must be not empty");

            RuleFor(I => I.UserId).NotEmpty().WithMessage("User Id must not be empty");

            RuleFor(I => I.BudgetDate.Frequency).NotEmpty().WithMessage("Frequency must not be empty");

            RuleFor(I => I.BudgetDate.FinishDate);

        }
    }
}