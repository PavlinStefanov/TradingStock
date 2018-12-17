using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.Domain.Stock.Events
{
    public class DownChangedEvent : EventBase
    {
        public DownChangedEvent()
        { }

        public DownChangedEvent(Guid id, double? down, int version)
        {
            Id = id;
            DownValue = down;
            Version = version;
        }

        /// <summary>
        /// 
        /// </summary>
        public readonly double? DownValue;
    }
}
