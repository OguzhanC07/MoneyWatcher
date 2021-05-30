using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MoneyWatcher.Businness.Abstract
{
    public interface IBudgetService:IGenericService<Budget,Guid>
    {
        public Task<Budget> GetBudgetWithDate(Guid id);
        public  Task<List<Budget>> GetSelectedDateBudgetsAsync(Guid id, int month, int year);
        Task<object> GetSelectedYearMonthlyDataAsnyc(Guid id);
    }
}
