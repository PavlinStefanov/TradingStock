using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.Domain.EventBus;
using TradingStock.Infrastructure.Context;
using TradingStock.Infrastructure.Repositories;
using TradingStock.MessageProvider.RabbitMQ;

namespace TradingStock.Business.Domain.Stock.Events
{
    public class DownChangedEventHandler : IBusEventHandler<DownChangedEvent>
    {
        private readonly IReadModelRepository _readModelRepository;
        private readonly IInterProcessBus _interProcessBus;
        private readonly ITradingStockDbContextFactory _dbContextFactory;

        public DownChangedEventHandler(ITradingStockDbContextFactory dbContextFactory, IInterProcessBus interProcessBus)
        {
            _dbContextFactory = dbContextFactory;
            _interProcessBus = interProcessBus;
        }

        /// <summary>
        /// 
        /// </summary>
        public Type HandlerType
        {
            get { return typeof(DownChangedEvent); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void Handle(DownChangedEvent @event)
        {
            try
            {
                var stock = _dbContextFactory.StockDbContext.Stocks.Find(@event.Id);
                stock.Down = @event.DownValue;
                stock.Version = @event.Version;

                _dbContextFactory.StockDbContext.Stocks.Update(stock);
                _dbContextFactory.StockDbContext.SaveChanges();

                _interProcessBus.SendMessage("DownChangedEvent");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to change Down value for event {@event.Id}", ex);
            }
        }
    }
}
