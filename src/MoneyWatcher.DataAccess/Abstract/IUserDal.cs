using System;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User,Guid>
    {
        
    }
}