using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Context;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class BudgetRepository : GenericRepository<Budget,Guid>, IBudgetDal
    {
        public async Task<Budget> GetBudgetWithDate(Guid id)
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Budgets.Include(I => I.BudgetDate).FirstOrDefaultAsync(I => I.Id == id);
        }

        public async Task<List<Budget>> GetSelectedDateBudgetsAsync(Guid id, int month, int year)
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Budgets
                .Include(I => I.BudgetDate)
                .Where(I => I.UserId == id)
                .Where(I =>
                    I.BudgetDate.StartDate.Month == month
                    && I.BudgetDate.StartDate.Year==year
                    || I.BudgetDate.IsMonthly == true
                    && month <= I.BudgetDate.FinishDate.Value.Month
                    && year==I.BudgetDate.FinishDate.Value.Year
                    )
                .ToListAsync();
        }

        public async Task<List<Budget>> GetSelectedDateTimeBudgetsAsync(Guid id, DateTime startDate,
            DateTime finishDate)
        {
            await using var context = new MoneyWatcherDbContext();
            
            return await context.Budgets.Include(I => I.BudgetDate)
                .Where(I => I.UserId == id)
                .Where(I=> 
                    I.BudgetDate.StartDate>=startDate
                    && I.BudgetDate.FinishDate.Value.Month<=finishDate.Month
                    && I.BudgetDate.FinishDate.Value.Year<=finishDate.Year
                    
                    )
                .ToListAsync();
        }
    }
}