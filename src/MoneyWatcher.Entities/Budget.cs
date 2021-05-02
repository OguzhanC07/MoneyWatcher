using System;

namespace MoneyWatcher.Entities
{
    public class Budget
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime Time { get; set; }
        public string PhotoString { get; set; }
        public bool IsActive { get; set; }


        public Guid UserGuid { get; set; }
        public User User { get; set; }
        
        public int BudgetCategoryId { get; set; }
        public BudgetCategory BudgetCategory { get; set; }
        
        public int TimeTypeId { get; set; }
        public TimeType TimeType { get; set; }
        
    }
}