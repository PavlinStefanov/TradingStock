using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Domain;
using TradingStock.Business.Domain.Stock.Commands;
using TradingStock.Business.Domain.Stock.Events;

namespace TradingStock.Business.Domain.Stock.DomainContext
{
    public class Stock : AggregateRoot
    {
        public string StockType { get; set; }
        public double? Up { get; set; }
        public double? Down { get; set; }
        public DateTime StockChange { get; set; }

        public Stock()
        { }
        //Guid id, string stockType, double? up, double? down, DateTime stockChange, int version, byte[] data
        public Stock(CreateStockCommand command)
        {
            Id = command.Id;
            ApplyChange(new StockCreatedEvent(command)); //id, stockType, up, down, stockChange, version, data
        }

        public void DownStock(double down)
        {
            ApplyChange(new DownChangedEvent(Id, down, Version));
        }
    }
}
