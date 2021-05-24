using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.Concrete;
using MoneyWatcher.Businness.JwtTools;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;
using MoneyWatcher.Businness.Utils.Dtos.UserDto;
using MoneyWatcher.Businness.Utils.FluentValidation;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories;

namespace MoneyWatcher.Businness.Utils.MicrosoftIoC
{
    public static class DependencyResolver
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericManager<,>));
            services.AddScoped(typeof(IGenericDal<,>), typeof(GenericRepository<,>));
            
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IBudgetService, BudgetManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBudgetDateService, BudgetDateManager>();

            services.AddScoped<IUserDal, UserRepository>();
            services.AddScoped<IBudgetDal, BudgetRepository>();
            services.AddScoped<IBudgetDateDal, BudgetDateRepository>();
            services.AddScoped<ICategoryDal, CategoryRepository>();

            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidation>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidation>();
            services.AddTransient<IValidator<BudgetAddDto>, BudgetAddDtoValidation>();
            services.AddTransient<IValidator<BudgetUpdateDto>,BudgetUpdateDtoValidation>();

            services.AddScoped<IJwtService, JwtManager>();
        }
    }
}