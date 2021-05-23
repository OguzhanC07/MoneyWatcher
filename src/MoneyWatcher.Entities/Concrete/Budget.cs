using MoneyWatcher.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Entities.Concrete
{
    public class Budget : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public bool BudgetType { get; set; }
       // public bool IsDeleted { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public BudgetDate BudgetDate { get; set; }
    }
}