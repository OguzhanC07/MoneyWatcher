using AutoMapper;
using MoneyWatcher.Entities.Concrete;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;

namespace MoneyWatcher.Web.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, RegisterDto>();
            CreateMap<RegisterDto, User>();

            CreateMap<User, LoginDto>();
            CreateMap<LoginDto, User>();


        }
    }
}
