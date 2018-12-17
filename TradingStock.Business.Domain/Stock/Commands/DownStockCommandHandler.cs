using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Commands;
using TradingStock.Business.CQRS.Domain;

namespace TradingStock.Business.Domain.Stock.Commands
{
    public class DownStockCommandHandler : ICommandHandler<DownStockCommand>
    {
        private readonly ISession _session;

        public DownStockCommandHandler(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void Handle(DownStockCommand command)
        {
            DomainContext.Stock stock = Get<DomainContext.Stock>(command.Id, command.ExpectedVersion);
            stock.DownStock(command.Down);

            _session.Commit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="expectedVersion"></param>
        /// <returns></returns>
        private T Get<T>(Guid id, int? expectedVersion = null) where T : AggregateRoot
        {
            try
            {
                return _session.Get<T>(id, expectedVersion);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to Fetch object of type {typeof(T)} with ID {id}.", ex);
            }
        }
    }
}
