
namespace TradingStock.Infrastructure.Context
{
    public class TradingStockDbContextFactory : ITradingStockDbContextFactory
    {
        public TradingStockDbContextFactory(TradingStockDbContext dbContext)
        {
            StockDbContext = dbContext;
        }

        /// <summary>
        /// StockDbContext property will allow communication with the SQL Database
        /// </summary>
        public TradingStockDbContext StockDbContext { get; set; }
    }
}
