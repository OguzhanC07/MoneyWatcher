using FluentValidation;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;

namespace MoneyWatcher.Businness.Utils.FluentValidation
{
    public class BudgetAddDtoValidation : AbstractValidator<BudgetAddDto>
    {
        public BudgetAddDtoValidation()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Name required");
            RuleFor(I => I.Name).Length(1, 50)
                .WithMessage("Name at least must be {MinLength} or maximum {MaxLength} long");
            
            RuleFor(I => I.Detail).NotEmpty().WithMessage("Detail required");
            RuleFor(I => I.Detail).Length(1, 50)
                .WithMessage("Detail at least must be {MinLength} or maximum {MaxLength} long");

            RuleFor(I => I.Price).NotEmpty().WithMessage("Price must be not empty");

            RuleFor(I => I.UserId).NotEmpty().WithMessage("User Id must not be empty");
            RuleFor(I => I.BudgetDate).NotNull().NotEmpty().WithMessage("BudgetDate cannot be null");
            When(I => I.BudgetDate != null, () =>
            {
                RuleFor(I => I.BudgetDate.StartDate).NotNull().NotEmpty().WithMessage("Start date cannot be empty");
                RuleFor(I => I.BudgetDate.FinishDate).GreaterThanOrEqualTo(I => I.BudgetDate.StartDate)
                    .WithMessage("Finish date cannot be equal or less than start date");
                When(I => I.BudgetDate.IsMontly == true, () =>
                {
                    RuleFor(I => I.BudgetDate.FinishDate)
                        .NotNull().WithMessage("Finish date cannot be null or empty if is monthly type is true");
                });
            });
        }
    }
}