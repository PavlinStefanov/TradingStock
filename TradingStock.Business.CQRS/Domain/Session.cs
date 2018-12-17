using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Domain
{
    public class Session : ISession
    {
        private readonly IRepository _repository;
        private readonly Dictionary<Guid, AggregateDescriptor> _trackedAggregates;

        public Session(IRepository repository)
        {
            _repository = repository;
            _trackedAggregates = new Dictionary<Guid, AggregateDescriptor>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aggregate"></param>
        public void Add<T>(T aggregate) where T : AggregateRoot
        {
            if (!isTracked(aggregate.Id))
                _trackedAggregates.Add(aggregate.Id, new AggregateDescriptor
                {
                    Aggregate = aggregate,
                    Version = aggregate.Version
                });
            else if (_trackedAggregates[aggregate.Id].Aggregate != aggregate)
                throw new Exception($"A different version than expected was found in aggregate {aggregate.Id}.");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="expectedVersion"></param>
        /// <returns></returns>
        public T Get<T>(Guid id, int? expectedVersion = null) where T : AggregateRoot
        {
            if (isTracked(id))
            {
                var trackedAggregate = (T)_trackedAggregates[id].Aggregate;

                if (expectedVersion != null && trackedAggregate.Version != expectedVersion)
                    throw new Exception($"A different version than expected was found in aggregate {trackedAggregate.Id}.");

                return trackedAggregate;
            }

            var aggregate = _repository.Get<T>(id);
            if (expectedVersion != null && aggregate.Version != expectedVersion)
                throw new Exception($"A different version than expected was found in aggregate {id}.");

            Add(aggregate);

            return aggregate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isTracked(Guid id)
        {
            return _trackedAggregates.ContainsKey(id);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            foreach (var descriptor in _trackedAggregates.Values)
            {
                _repository.Save(descriptor.Aggregate, descriptor.Version);
            }
            _trackedAggregates.Clear();
        }

       
        private class AggregateDescriptor
        {
            public AggregateRoot Aggregate { get; set; }
            public int Version { get; set; }
        }
    }
}
