﻿using System;

namespace MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto
{
    public class BudgetDateUpdateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool IsMonthly { get; set; } 
    }
}