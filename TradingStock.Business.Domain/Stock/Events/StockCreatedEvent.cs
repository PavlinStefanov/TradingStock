using System;
using TradingStock.Business.Domain.Stock.Commands;
using TradingStock.Storage.EventStore.Utils;

namespace TradingStock.Business.Domain.Stock.Events
{
    public class StockCreatedEvent : EventBase
    {
        public StockCreatedEvent() { }
        //CreateStockCommand command
        //Guid id, string stockType, double? up, double? down, DateTime stockChange, int version, byte[] data
        public StockCreatedEvent(CreateStockCommand command)
        {
            Id = command.Id;
            StockType = command.StockType;
            Up = command.Up;
            Down = command.Down;
            StockChange = command.StockChange;
            Version = command.ExpectedVersion;
            Metadata = command.AsJsonString().AsByteArray();
        }

        public string StockType { get; set; }
        public double? Up { get; set; }
        public double? Down { get; set; }
        public DateTime StockChange { get; set; }
    }
}
