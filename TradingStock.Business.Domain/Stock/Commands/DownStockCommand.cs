using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Commands;

namespace TradingStock.Business.Domain.Stock.Commands
{
    public class DownStockCommand : Command
    {
        public DownStockCommand(Guid aggregateRootId, double down, int expectedVersion)
        {
            Id = aggregateRootId;
            Down = down;
            ExpectedVersion = expectedVersion;
        }

        /// <summary>
        /// 
        /// </summary>
        //public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Down { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public int ExpectedVersion { get; set; }
    }
}
