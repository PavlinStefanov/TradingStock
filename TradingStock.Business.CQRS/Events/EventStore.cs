using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingStock.Business.CQRS.Utils;
using TradingStock.Infrastructure.Context;
using TradingStock.Infrastructure.Model;

namespace TradingStock.Business.CQRS.Events
{
    /// <summary>
    /// towa trqbwa da se izmesti wyw Storage.EventStore proekta
    /// </summary>
    public class EventStore : IEventStore
    {
        private readonly ITradingStockDbContextFactory _dbContextFactory;

        public EventStore(ITradingStockDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggreagteId"></param>
        /// <param name="fromVersion"></param>
        /// <returns></returns>
        public IEnumerable<Event> Get(Guid aggreagteId, int fromVersion)
        {
            var events = _dbContextFactory.StockDbContext.StockEvents
                .Where(x => x.AggregateId == aggreagteId && x.Version > fromVersion)
                .Select(x => new Event
                {
                    Id = x.EventId,
                    Version = x.Version,
                    TimeStamp = x.TimeStamp
                });

            return events;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void Save(IEvent @event)
        {
            _dbContextFactory.StockDbContext.StockEvents.Add(new StockEvent
            {
                AggregateId = @event.Id,  // to fix this one
                EventId = Guid.NewGuid(),
                Version = @event.Version,
                EventType = @event.GetType().ToString(),
                TimeStamp = @event.TimeStamp
            });
            _dbContextFactory.StockDbContext.SaveChanges();
        }
    }
}
