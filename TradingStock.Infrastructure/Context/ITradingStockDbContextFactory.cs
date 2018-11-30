
namespace TradingStock.Infrastructure.Context
{
    public interface ITradingStockDbContextFactory
    {
        TradingStockDbContext StockDbContext { get; set; }
    }
}
