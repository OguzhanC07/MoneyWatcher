using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;

namespace MoneyWatcher.Businness.Abstract
{
    public interface IUserService:IGenericService<User,Guid>
    {
        public  Task<User> LoginValidate(LoginDto loginDto);
        public Task<User> FindUserByEmail(string email);
    }
}
