using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.DatatransferObjects;
using TradingStock.Infrastructure.Context;

namespace TradingStock.Business.Domain.Stock.Queries
{
    public class StockByTypeQueryHandler : IQueryHandler<StockByTypeQuery, IEnumerable<StockByTypeDto>>
    {
        private readonly ITradingStockDbContextFactory _contextFactory;

        public StockByTypeQueryHandler(ITradingStockDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary> 
        /// Execute method will return all Stocks by selected type
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IEnumerable<StockByTypeDto> Execute(StockByTypeQuery query)
        {
            try
            {
                var context = _contextFactory.StockDbContext;
                return context.Stocks.Where(stock => stock.StockType == query.StockType)
                    .ToDto();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to Fetch Stocks table for Stock Type '{query.StockType}'.", ex);
            }
        }
    }
}
