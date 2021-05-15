using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.DTOs.UserDTO;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Concrete
{
    public class UserManager : GenericManager<User, Guid>, IUserService
    {
        private IGenericDal<User, Guid> _genericDal;

        public UserManager(IGenericDal<User, Guid> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<User> LoginValidate(LoginDTO loginDTO)
        {
            var user = await _genericDal.GetByFilter(I => I.Email == loginDTO.Email);
            if (user == null)
            {
                return null;
            }
            else if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
            {
                return null;
            }

            return user;
        }

    }
}
