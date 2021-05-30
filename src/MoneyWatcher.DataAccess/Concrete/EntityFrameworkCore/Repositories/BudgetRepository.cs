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
	        var firstDateOfMonth = new DateTime(year, month, 1);
	        var lastDateOfMonth = firstDateOfMonth.AddMonths(1).Subtract(TimeSpan.FromSeconds(1));
            await using var context = new MoneyWatcherDbContext();
            return await context.Budgets
                .Include(I => I.BudgetDate)
                .Where(I => I.UserId == id)
                .Where(I =>
                    I.BudgetDate.StartDate.Month == month
                    && I.BudgetDate.StartDate.Year==year
                    || I.BudgetDate.IsMonthly 
                    && lastDateOfMonth >= I.BudgetDate.StartDate
                    && firstDateOfMonth <= I.BudgetDate.FinishDate.Value
                    )
                .ToListAsync();
        }

        
        //This method ONLY GETS ONE TIME BUDGETS NOT MONTHLY BUDGETS
        public async Task<object> GetSelectedYearMonthlyDataAsnyc(Guid id)
        {
            await using var context = new MoneyWatcherDbContext();
            var results = await context.Budgets
                .Include(I => I.BudgetDate)
                .Where(I => I.UserId == id)
                .Where(I =>
                    I.BudgetDate.StartDate.Year == DateTime.Now.Year
                    // || I.BudgetDate.IsMonthly
                    // && I.BudgetDate.FinishDate.Value.Year >= DateTime.Now.Year
                ).
                GroupBy(I=>new {StartDate= I.BudgetDate.StartDate.Month, I.BudgetType})
                .Select(I=>new
                {
                    I.Key.StartDate,
                    Income =I.Key.BudgetType ? I.Sum(a=>a.Price): 0,
                    OutCome= I.Key.BudgetType==false ? I.Sum(a=>a.Price):0
                })
                .ToListAsync();
            return new {MonthlyData = results};
        }
        
    }
}