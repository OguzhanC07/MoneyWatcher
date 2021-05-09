using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Context;
using MoneyWatcher.Entities.Abstract;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class GenericRepository<T,TId> : IGenericDal<T,TId> where T:class,IEntity,new()
    {
        public async Task<T> GetByIdAsync(TId id)
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> expression)
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T,bool>> expression)
        {
            await using var context = new MoneyWatcherDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task AddAsync(T entity)
        {
            await using var context = new MoneyWatcherDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await using var context = new MoneyWatcherDbContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await using var context = new MoneyWatcherDbContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}