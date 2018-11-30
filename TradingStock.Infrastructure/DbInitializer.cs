using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingStock.Infrastructure.Context;
using TradingStock.Infrastructure.Model;

namespace TradingStock.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(TradingStockDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Stocks.Any())
            {
                var stocks = new Stock[]
                {
                    new Stock{ ID = Guid.NewGuid(), StockType = "Gold", Down = 0.234, Up = null, StockChange = DateTime.Now},
                    new Stock{ ID = Guid.NewGuid(), StockType = "Gold", Down = null, Up = 0.123, StockChange = DateTime.Now},
                    new Stock{ ID = Guid.NewGuid(), StockType = "Gold", Down = null, Up = 0.211, StockChange = DateTime.Now},
                };

                context.AddRange(stocks);
                context.SaveChanges();
            }
        }
    }
}
