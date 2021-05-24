using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Abstract
{
    public interface IBudgetDal : IGenericDal<Budget,Guid>
    {
        public Task<List<Budget>> GetThisMonthBudgetsAsync(Guid Id);
        public Task<Budget> GetBudgetWithDate(Guid id);
    }
}