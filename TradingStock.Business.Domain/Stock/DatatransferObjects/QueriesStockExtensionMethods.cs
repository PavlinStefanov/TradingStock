using System;
using System.Collections.Generic;
using System.Linq;

namespace TradingStock.Business.Domain.Stock.DatatransferObjects
{
    public static class QueriesStockExtensionMethods
    {
        public static IEnumerable<StockByTypeDto> ToDto(this IEnumerable<Infrastructure.Model.Stock> stocks)
        {
            return stocks.Select(stock => new StockByTypeDto
            {
                ID = stock.ID,
                StockType = stock.StockType,
                Up = stock.Up,
                Down = stock.Down,
                StockChange = stock.StockChange
            });
        }
    }
}
