using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Events;
using TradingStock.Business.CQRS.Utils;

namespace TradingStock.Business.CQRS.Domain
{
    public class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();

        public Guid Id { get; protected set; }
        public int Version { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEvent> GetUncommitedChanges()
        {
            lock (_changes)
            {
                return _changes.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void MarkChangesAsCommited()
        {
            lock (_changes)
            {
                Version = Version + _changes.Count;
                _changes.Clear();
            }
        }

        /// <summary>
        /// it's toocks all events for given aggregate from EventStore
        /// </summary>
        /// <param name="history"></param>
        public void LoadFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var @event in history)
            {
                if (@event.Version != Version + 1)
                    throw new Exception($"The Event {@event.Id} is out of the order.");
                ApplyChange(@event, false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        protected void ApplyChange(IEvent @event)
        {
            ApplyChange(@event, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="isNew"></param>
        private void ApplyChange(IEvent @event, bool isNew)
        {
            lock (_changes)
            {
                this.AsDynamic().Apply(@event);
                if (isNew)
                {
                    _changes.Add(@event);
                }
                else
                {
                    Id = @event.Id;
                    Version++;
                }
            }
        }
    }
}
