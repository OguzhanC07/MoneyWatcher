using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MoneyWatcher.Entities.Abstract;

namespace MoneyWatcher.DataAccess.Abstract
{
    public interface IGenericDal<T, in TId> where  T: class,IEntity,new()
    {
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllByFilter(Expression<Func<T,bool>> expression);
        Task<T> GetByFilter(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}