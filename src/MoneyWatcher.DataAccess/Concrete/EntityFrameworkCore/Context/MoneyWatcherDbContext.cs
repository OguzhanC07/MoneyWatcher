using Microsoft.EntityFrameworkCore;
using MoneyWatcher.DataAccess.Concrete.Mapping;
using MoneyWatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyWatcher.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class MoneyWatcherDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6KNLK68\\SQLEXPRESS; Database=MoneyWatcher;uid=sa;pwd=1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BudgetDateMap());
            modelBuilder.ApplyConfiguration(new BudgetMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetDate> BudgetDates { get; set; }
    }
}
