using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Abstract
{
    public interface IUserService:IGenericService<User,Guid>
    {
    }
}
