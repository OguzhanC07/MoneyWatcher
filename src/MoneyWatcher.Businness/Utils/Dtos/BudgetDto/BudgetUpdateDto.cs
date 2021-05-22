using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Utils.Dtos.BudgetDto
{
    public  class BudgetUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public int CategoryId { get; set; }
        public bool BudgetType { get; set; }
        public Guid UserId { get; set; }
        public BudgetDateUpdateDto BudgetDate { get; set; }
    }
}
