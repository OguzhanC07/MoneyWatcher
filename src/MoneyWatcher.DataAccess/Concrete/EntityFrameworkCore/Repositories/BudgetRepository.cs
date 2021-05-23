using System;
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
        
    }
}