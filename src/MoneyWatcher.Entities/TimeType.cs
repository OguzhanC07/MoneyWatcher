﻿using System.Collections.Generic;

namespace MoneyWatcher.Entities
{
    public class TimeType
    { 
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Budget> Budgets { get; set; }
    }
}