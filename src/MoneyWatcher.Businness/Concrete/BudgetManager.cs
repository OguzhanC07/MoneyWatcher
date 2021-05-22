using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Concrete
{
    public class BudgetManager:GenericManager<Budget,Guid>,IBudgetService
    {
        private readonly IGenericDal<Budget, Guid> _genericDal;
        private readonly IBudgetDal _budgetDal;

        public BudgetManager(IGenericDal<Budget, Guid> genericDal, IBudgetDal budgetDal):base(genericDal)
        {
            _genericDal = genericDal;
            _budgetDal = budgetDal;
        }

        public async Task AddBudget(Budget budget)
        {
            await _budgetDal.AddBudget(budget);
        }

    }
}
