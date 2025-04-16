using Microsoft.EntityFrameworkCore;
using RefuApi.Models;
using Microsoft.Extensions.Logging;

namespace BankApp.Data
{
    public class RefuApiContext : DbContext
    {

        public RefuApiContext(DbContextOptions<RefuApiContext> options)
            : base(options)
        {

        }

      protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount { Number = "1234567890", Owner = "John Doe"},
                new BankAccount { Number = "0987654321", Owner = "Jane Doe"}
            );
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionId = 1, Amount = 200.00m, BankAccountId="1234567890", Date = new DateTime(2021,01,01,10,0,0), Note = "Deposito inicial"},
                new Transaction { TransactionId = 2, Amount = 300.00m, BankAccountId="1234567890", Date = new DateTime(2021,01,02,11,0,0), Note = "Deposito"},
                new Transaction { TransactionId = 3, Amount = -150.00m, BankAccountId="1234567890", Date = new DateTime(2021,01,03,9,30,0), Note = "Retiro"},
                new Transaction { TransactionId = 4, Amount = 400.00m, BankAccountId="0987654321", Date = new DateTime(2021,01,04,14,0,0), Note = "Deposito"}
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(); // Opcional
        }


        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
       
    }
}
