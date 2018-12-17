using System;
using System.Collections.Generic;
using TradingStock.Business.Domain.EventBus;
using TradingStock.Infrastructure.Context;
using TradingStock.Infrastructure.Repositories;
using TradingStock.MessageProvider.RabbitMQ;

namespace TradingStock.Business.Domain.Stock.Events
{
    public class StockCreatedEventHandler : IBusEventHandler<StockCreatedEvent>
    {
        private readonly IReadModelRepository _readModelRepository;
        private readonly IInterProcessBus _interProcessBus;
        private readonly ICommandRepository<Infrastructure.Model.Stock> _commandRepository; 
        public StockCreatedEventHandler(ICommandRepository<Infrastructure.Model.Stock> commandRepository, IReadModelRepository readModelRepository, IInterProcessBus interProcessBus)
        {
            _readModelRepository = readModelRepository;
            _interProcessBus = interProcessBus;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        public Type HandlerType
        {
            get { return typeof(StockCreatedEvent); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void Handle(StockCreatedEvent @event)
        {
            _commandRepository.Insert(new Infrastructure.Model.Stock()
            {
                ID = @event.Id,
                StockType = @event.StockType,
                Up = @event.Up,
                Down = @event.Down,
                StockChange = @event.StockChange
            });
            _commandRepository.Commit();
            _interProcessBus.SendMessage("OrderCreatedEvent");
        }
    }
}
