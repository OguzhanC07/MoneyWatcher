using System;
using FluentValidation;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;

namespace MoneyWatcher.Businness.Utils.FluentValidation
{
    public class DateDtoValidation:AbstractValidator<DateDto>
    {
        public DateDtoValidation()
        {
            RuleFor(I => I.MonthNum).LessThan(13).GreaterThan(0).WithMessage("Please select right date for month");
            RuleFor(I => I.YearNum).GreaterThanOrEqualTo(1999).LessThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("Please select right date for year");
        }
    }
}