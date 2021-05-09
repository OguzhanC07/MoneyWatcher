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
    public class BudgetDateManager:GenericManager<BudgetDate,Guid>,IBudgetDateService
    {
        private IGenericDal<BudgetDate, Guid> _genericDal;
        public BudgetDateManager(IGenericDal<BudgetDate, Guid> genericDal):base(genericDal)
        {
            
        }
    }
}
