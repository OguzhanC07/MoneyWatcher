using System;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.Businness.Utils.Dtos.BudgetDto
{
    public class BudgetDetailDto
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public bool BudgetType { get; set; }
        public BudgetDateDetailDto BudgetDate { get; set; }
    }
}