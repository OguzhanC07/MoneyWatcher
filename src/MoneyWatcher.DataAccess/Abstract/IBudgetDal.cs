using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Abstract
{
    public interface IBudgetDal : IGenericDal<Budget,Guid>
    {
        public Task<Budget> GetBudgetWithDate(Guid id);
        public Task<List<Budget>> GetSelectedDateBudgetsAsync(Guid id, int month, int year);
    }
}