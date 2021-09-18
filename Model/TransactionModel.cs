using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Model
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Category> Categories { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlite(@"Data Source=/tmp/ExpenseTracker.db");
        }
 
    }
}