using System;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;

namespace MoneyWatcher.Businness.Utils.Dtos.BudgetDto
{
    public class BudgetUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public bool BudgetType { get; set; }
        public int CategoryId { get; set; }
        public BudgetDateUpdateDto BudgetDate { get; set; }
    }
}