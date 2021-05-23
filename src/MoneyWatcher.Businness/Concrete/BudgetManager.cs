using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Concrete
{
    public class BudgetManager:GenericManager<Budget,Guid>,IBudgetService
    {
        private readonly IBudgetDal _budgetDal;
        public BudgetManager(IGenericDal<Budget, Guid> genericDal,IBudgetDal budgetDal):base(genericDal)
        {
            _budgetDal = budgetDal;
        }

        public Task<Budget> GetBudgetWithDate(Guid id)
        {
            return _budgetDal.GetBudgetWithDate(id);
        }
    }
}
