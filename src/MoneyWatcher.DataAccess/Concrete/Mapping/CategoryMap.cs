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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasKey(I => I.Id);

            builder.Property(I => I.Name).HasMaxLength(50);

            builder.HasMany(I => I.Budgets).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId).OnDelete(DeleteBehavior.NoAction);

        }
    }

}
