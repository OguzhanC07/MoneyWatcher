using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;
using System;

namespace MoneyWatcher.Businness.Concrete
{
    public class BudgetManager:GenericManager<Budget,Guid>,IBudgetService
    {
        public BudgetManager(IGenericDal<Budget, Guid> genericDal):base(genericDal)
        {
        }

    }
}
