using AutoMapper;
using MoneyWatcher.Entities.Concrete;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;
using MoneyWatcher.Businness.Utils.Dtos.CategoryDto;

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

            CreateMap<Budget, BudgetDetailDto>();
            CreateMap<BudgetDetailDto, Budget>();
            
            CreateMap<Budget, BudgetAddDto>();
            CreateMap<BudgetAddDto, Budget>();

            CreateMap<BudgetDate,BudgetDateDetailDto>();
            CreateMap<BudgetDateDetailDto, BudgetDate>();
            
            CreateMap<BudgetDate, BudgetDateUpdateDto>();
            CreateMap<BudgetDateUpdateDto, BudgetDate>();

            CreateMap<BudgetDate, BudgetDateAddDto>();
            CreateMap<BudgetDateAddDto, BudgetDate>();

            CreateMap<Category, CategoryDetailDto>();
            CreateMap<CategoryDetailDto, Category>();
        }
    }
}
