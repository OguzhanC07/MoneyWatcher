using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Concrete
{
    public class CategoryManager:GenericManager<Category,int>,ICategoryService
    {
        private IGenericDal<Category,int> _genericDal;

        public CategoryManager(IGenericDal<Category, int> _genericDal):base(_genericDal)
        {

        }
    }
}
