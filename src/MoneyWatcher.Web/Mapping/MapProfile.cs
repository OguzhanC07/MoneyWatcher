using AutoMapper;
using MoneyWatcher.Entities.Concrete;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;

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

            CreateMap<Budget, BudgetUpdateDto>();
            CreateMap<BudgetUpdateDto, Budget>();

            CreateMap<BudgetDate, BudgetDateUpdateDto>();
            CreateMap<BudgetDateUpdateDto, BudgetDate>();
        }
    }
}
