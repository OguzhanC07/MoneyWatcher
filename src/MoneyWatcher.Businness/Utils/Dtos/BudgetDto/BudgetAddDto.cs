using System;
using System.ComponentModel;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;
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
        public BudgetDateAddDto BudgetDate { get; set; }
    }
}