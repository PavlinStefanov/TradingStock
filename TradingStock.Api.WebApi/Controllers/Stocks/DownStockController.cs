using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingStock.Business.CQRS.Commands;
using TradingStock.Business.Domain.Stock.Commands;
using TradingStock.Storage.EventStore.EsContext;

namespace TradingStock.Api.WebApi.Controllers.Stocks
{
    [Produces("application/json")]
    [Route("api/stocks")]
    public class DownStockController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public DownStockController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPatch("updateDownStock")]
        public IActionResult UpdateDownStockValueAsync()
        {
            var aggregateId = Guid.Parse("7F676FE2-1643-4556-8861-F66791957AA1");

            //var result =  FetchEventsByAggregateAsync(aggregateId, -1).GetAwaiter();

            var command = new DownStockCommand(aggregateId, 5.442, 1);
            _commandDispatcher.DispatchCommand(command);

            return new OkObjectResult("OK");
        }

        public async Task<byte[]> FetchEventsByAggregateAsync(Guid aggregateId, int fromVersion)
        {
            using (var connection = EventStoreConnectionFactory.Default())
            {
                try
                {
                    connection.ConnectAsync().Wait();

                    var re = await connection.ReadEventAsync(aggregateId.ToString(), 0, false, EventStoreCredentials.Default);// .ReadStreamEventsForwardAsync(aggr, 1, 1, true);
                    return re.Event.Value.Event.Data;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}