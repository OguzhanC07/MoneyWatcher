using System;
using System.Threading.Tasks;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Context;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class BudgetRepository : GenericRepository<Budget,Guid>, IBudgetDal
    {
    }
}