using MoneyWatcher.Entities.Concrete;
using System;
using System.Threading.Tasks;


namespace MoneyWatcher.Businness.Abstract
{
    public interface IBudgetService:IGenericService<Budget,Guid>
    {
        public Task<Budget> GetBudgetWithDate(Guid id);
    }
}
