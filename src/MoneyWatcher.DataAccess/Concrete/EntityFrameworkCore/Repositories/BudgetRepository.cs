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

        public async Task<List<Budget>> GetThisMonthBudgetsAsync(Guid id)
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Budgets
                .Include(I => I.BudgetDate)
                .Where(I => I.UserId == id)
                .Where(I=>
                    I.BudgetDate.StartDate.Month==DateTime.Now.Month 
                          && I.BudgetDate.StartDate.Year == DateTime.Now.Year
                          || I.BudgetDate.IsMonthly==true 
                          &&  DateTime.Now.Month<=I.BudgetDate.FinishDate.Value.Month
                          && DateTime.Now.Year == I.BudgetDate.FinishDate.Value.Year
                          )
                .ToListAsync();
        }
    }
}