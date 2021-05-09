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
    public class UserManager:GenericManager<User,Guid>,IUserService
    {
        private IGenericDal<User,Guid> _genericDal;
        public UserManager(IGenericDal<User, Guid> genericDal):base(genericDal)
        {

        }
    }
}
