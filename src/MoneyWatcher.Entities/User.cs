using System;
using System.Collections.Generic;

namespace MoneyWatcher.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Budget> Budgets { get; set; }
    }
}