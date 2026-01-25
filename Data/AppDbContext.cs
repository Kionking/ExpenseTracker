using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
    }
}
