using System;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.Businness.Utils.Dtos.BudgetDto
{
    public class BudgetAddDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public bool BudgetType { get; set; }
        public Guid UserId { get; set; }
        public int CategoryId { get; set; }
        public BudgetDate BudgetDate { get; set; }
    }
}