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
    public class UserMap : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(I => I.Id).ValueGeneratedOnAdd();
            builder.HasKey(I => I.Id);

            builder.Property(I => I.Email).HasMaxLength(150);
            builder.Property(I => I.Password).HasMaxLength(50);
            builder.Property(I => I.FullName).HasMaxLength(50);

            builder.HasMany(I => I.Budgets).WithOne(I => I.User).HasForeignKey(I => I.UserId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
