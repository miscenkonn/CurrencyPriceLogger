using Microsoft.EntityFrameworkCore;
using CurrencyPriceLogger.Models;

namespace CurrencyPriceLogger.Database
{
    public class SymbolContext : DbContext
    {
        public DbSet<SymbolBookData> Symbols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CurrencyPriceLoggerDB;Trusted_Connection=True;");
        }
    }
}
