using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.Businness.Concrete
{
    public class CategoryManager:GenericManager<Category,int>,ICategoryService
    {
        public CategoryManager(IGenericDal<Category, int> genericDal):base(genericDal)
        {

        }
    }
}
