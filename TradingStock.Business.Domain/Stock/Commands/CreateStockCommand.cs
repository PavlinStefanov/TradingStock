using System;
using TradingStock.Business.CQRS.Commands;

namespace TradingStock.Business.Domain.Stock.Commands
{
    public class CreateStockCommand : Command
    {
        public CreateStockCommand(Guid aggregateRootId, int version, string stockType, double up, double down) 
        {
            Id = aggregateRootId;
            StockType = stockType;
            Up = up;
            Down = down;
            StockChange = DateTime.Now;
            ExpectedVersion = version;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid Id{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StockType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Up { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Down { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime StockChange { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int ExpectedVersion { get; set; }
    }
}
