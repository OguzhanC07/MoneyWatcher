using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Concrete
{
    public class GenericManager<T, TId> : IGenericService<T, TId> 
        where T:class,IEntity,new()
    {
        private readonly IGenericDal<T,TId> _genericDal;

        public GenericManager(IGenericDal<T,TId> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task AddAsync(T entity)
        {
           await _genericDal.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await _genericDal.DeleteAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        
    }
}
