using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskBackEnd.Context.Configuration;
using TaskBackEnd.Entites;

namespace TaskBackEnd.Context
{
    public class BankContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRatio> CurrenciesRatio { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false; // I will explain it to you later
            /*
             * Lazy Loading : multible querie s 
             * Eadger Loading : one query (include) 
             * */
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CustomerConfiguration(modelBuilder.Entity<Customer>());
            new TransactionConfiguration(modelBuilder.Entity<Transaction>());
            new AccountConfiguration(modelBuilder.Entity<Account>());
            new AccountTypeConfiguration(modelBuilder.Entity<AccountType>());
            new CurrencyConfiguration(modelBuilder.Entity<Currency>());
            new CurrencyRatioConfiguration(modelBuilder.Entity<CurrencyRatio>());
            new OperationConfiguration(modelBuilder.Entity<Operation>());

        }

    }
}
