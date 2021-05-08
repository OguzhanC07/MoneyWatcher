﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.DataAccess.Concrete.Mapping
{
    public class BudgetDateMap : IEntityTypeConfiguration<BudgetDate>
    {
        public void Configure(EntityTypeBuilder<BudgetDate> builder)
        {
            builder.Property(I => I.Id).ValueGeneratedOnAdd();
            builder.HasKey(I => I.Id);

            builder.HasOne(I => I.Budget).WithOne(I => I.BudgetDate).HasForeignKey<Budget>(I => I.Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
