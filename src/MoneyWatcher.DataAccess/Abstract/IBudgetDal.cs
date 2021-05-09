using System;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Abstract
{
    public interface IBudgetDal : IGenericDal<Budget,Guid>
    {
        
    }
}