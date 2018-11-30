using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.DatatransferObjects;

namespace TradingStock.Business.Domain.Stock.Queries
{
    public class StockByTypeQuery : IQuery<IEnumerable<StockByTypeDto>>
    {
        public StockByTypeQuery(string stockType)
        {
            StockType = stockType;
        }

        /// <summary>
        /// StockType property will store Stock type filter criteria
        /// </summary>
        public string StockType { get; }
    }
}
