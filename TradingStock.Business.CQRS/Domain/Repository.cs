using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingStock.Business.CQRS.Events;
using TradingStock.Business.CQRS.Utils;
using TradingStock.Storage.EventStore.Storage;

namespace TradingStock.Business.CQRS.Domain
{
    public class Repository : IRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _eventPublisher;
        private readonly IEventStorage _eventStorage;
        public Repository(IEventStore eventStore, IEventPublisher eventPublisher, IEventStorage eventStorage)
        {
            _eventStore = eventStore;
            _eventPublisher = eventPublisher;
            _eventStorage = eventStorage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregateId"></param>
        /// <returns></returns>
        public T Get<T>(Guid aggregateId) where T : AggregateRoot
        {
            return LoadAggregate<T>(aggregateId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregate"></param>
        /// <param name="expectedVersion"></param>
        public void Save<T>(T aggregate, int? expectedVersion = null) where T : AggregateRoot
        {
            if (expectedVersion != null && _eventStore.Get(aggregate.Id, expectedVersion.Value).Any())
                throw new Exception($"A different version than expected was found in aggregate {aggregate.Id}.");

            int i = 0;
            foreach (var @event in aggregate.GetUncommitedChanges())
            {
                if (@event.Id == Guid.Empty)
                    @event.Id = aggregate.Id;
                i++;
                @event.Version = aggregate.Version + 1;
                @event.TimeStamp = DateTimeOffset.UtcNow;

                _eventStore.Save(@event);
                _eventPublisher.Publish(@event);
                //_eventStorage.AppentToAggregate(aggregate.Id, @event.ToEventData());
            }

            aggregate.MarkChangesAsCommited();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        private T LoadAggregate<T>(Guid id) where T : AggregateRoot
        {
            var aggreagteRoot = AggregateFactory.CreateAggregate<T>();
            //byte[] aggregateEvents = _eventStorage.FetchEventsByAggregateAsync(id, -1).GetAwaiter().GetResult();
            //var events = aggregateEvents.AsJsonString();
            var events = _eventStore.Get(id, -1);
            
            if (!events.Any())
                throw new Exception($"Missing Aggregate {id}.");

            aggreagteRoot.LoadFromHistory(events);

            return aggreagteRoot;
        }
    }
}
