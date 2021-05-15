using System;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.Concrete;
using MoneyWatcher.Businness.DTOs.UserDTO;
using MoneyWatcher.Businness.FluentValidation;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories;

namespace MoneyWatcher.Businness.MicrosoftIoC
{
    public static class DependencyResolver
    {
        public static void AddDependicies(this IServiceCollection services)
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

            services.AddTransient<IValidator<RegisterDTO>, RegisterDTOValidation>();
        }
    }
}
