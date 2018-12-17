using System;
using TradingStock.Business.CQRS.Commands;
using TradingStock.Business.CQRS.Domain;
using TradingStock.Infrastructure.Context;
using TradingStock.Storage.EventStore.Utils;

namespace TradingStock.Business.Domain.Stock.Commands
{
    public class CreateStockCommandHandler : ICommandHandler<CreateStockCommand>
    {
        //private readonly ITradingStockDbContextFactory _tradingStockDbContextFactory;
        private readonly ISession _session;

        public CreateStockCommandHandler(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void Handle(CreateStockCommand command)
        {
            try
            {
                //byte[] data = command.AsJsonString().AsByteArray();
                //command.Id, command.StockType, command.Up, command.Down, command.StockChange, command.ExpectedVersion, data
                var stock = new DomainContext.Stock(command);

                _session.Add(stock);
                _session.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to create new stock.", ex);
            }
        }
    }
}
