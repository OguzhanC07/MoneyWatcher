
using MoneyWatcher.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Abstract
{
    public interface IGenericService<T, in TId> 
        where T:class,IEntity,new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> GetAllAsync();

    }
}
