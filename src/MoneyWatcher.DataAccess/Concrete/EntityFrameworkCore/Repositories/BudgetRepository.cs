using System;
using System.Threading.Tasks;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Context;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class BudgetRepository : GenericRepository<Budget,Guid>, IBudgetDal
    {
        public async Task AddBudget(Budget budget)
        {
            await using var context = new MoneyWatcherDbContext();
            var Budget = new Budget
            {
                Name = budget.Name,
                Detail = budget.Detail,
                Price = budget.Price,
                BudgetType = budget.BudgetType,
            };
            context.Add(Budget);
            await context.SaveChangesAsync();

            var BudgetDate = new BudgetDate
            {
                BudgetId = Budget.Id,
                StartDate = budget.BudgetDate.StartDate,
                FinishDate = budget.BudgetDate.FinishDate,
                Frequency = budget.BudgetDate.Frequency
            };
            context.Add(BudgetDate);
            await context.SaveChangesAsync();
        }
    }
}