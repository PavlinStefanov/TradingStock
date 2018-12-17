using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradingStock.Business.CQRS.Events
{
    public class InMemoryEventStore 
    {
        private readonly Dictionary<Guid, List<IEvent>> _inMemoryDb = new Dictionary<Guid, List<IEvent>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aggreagteId"></param>
        /// <param name="fromVersion"></param>
        /// <returns></returns>
        public IEnumerable<IEvent> Get(Guid aggreagteId, int fromVersion)
        {
            try
            {
                List<IEvent> events;
                _inMemoryDb.TryGetValue(aggreagteId, out events);
                return events != null
                    ? events.Where(x => x.Version > fromVersion)
                    : new List<IEvent>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get events for Agreggate {aggreagteId}", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public void Save(IEvent @event)
        {
            List<IEvent> list;
            _inMemoryDb.TryGetValue(@event.Id, out list);
            if (list == null)
            {
                list = new List<IEvent>();
                _inMemoryDb.Add(@event.Id, list);
            }
            list.Add(@event);
        }
    }
}
