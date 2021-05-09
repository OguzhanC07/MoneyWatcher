using MoneyWatcher.DataAccess.Abstract;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : GenericRepository<Category,int>, ICategoryDal
    {
    }
}