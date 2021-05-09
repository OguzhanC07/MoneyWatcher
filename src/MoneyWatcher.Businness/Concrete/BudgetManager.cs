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
        private IGenericDal<Budget, Guid> _genericDal;

        public BudgetManager(IGenericDal<Budget, Guid> genericDal):base(genericDal)
        {

        }

    }
}
