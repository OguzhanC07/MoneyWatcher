using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.DataAccess.Concrete.Mapping
{
    public class BudgetMap : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.Property(I => I.Id).ValueGeneratedOnAdd();
            builder.HasKey(I => I.Id);

            builder.Property(I => I.Name).HasMaxLength(50);
            builder.Property(I => I.Detail).HasMaxLength(250);
           
            builder.HasOne(I => I.BudgetDate).WithOne(I => I.Budget).HasForeignKey<Budget>(I => I.BudgetDateId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
