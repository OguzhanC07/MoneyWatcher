using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Threading.Tasks;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;


namespace MoneyWatcher.Businness.Concrete
{
    public class UserManager : GenericManager<User, Guid>, IUserService
    {
        private readonly IGenericDal<User, Guid> _genericDal;

        public UserManager(IGenericDal<User, Guid> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<User> LoginValidate(LoginDto loginDto)
        {
            var user = await _genericDal.GetByFilter(I => I.Email == loginDto.Email);
            if (user == null)
            {
                return null;
            }

            return !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password) ? null : user;
        }

    }
}
