using System;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class UserRepository : GenericRepository<User,Guid>, IUserDal
    {
    }
}