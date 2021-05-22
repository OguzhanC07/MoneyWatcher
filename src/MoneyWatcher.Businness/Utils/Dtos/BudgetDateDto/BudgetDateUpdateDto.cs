using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto
{
    public class BudgetDateUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Frequency { get; set; }
        //public Guid BudgetId { get; set; }

    }
}
