using Microsoft.EntityFrameworkCore;
using TradingStock.Infrastructure.Configuration;
using TradingStock.Infrastructure.Model;

namespace TradingStock.Infrastructure.Context
{
    public class TradingStockDbContext : DbContext
    {
        public TradingStockDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StockConfiguration());
        }


        #region Entity Sets
        public DbSet<Stock> Stocks { get; set; }
        #endregion
    }
}
