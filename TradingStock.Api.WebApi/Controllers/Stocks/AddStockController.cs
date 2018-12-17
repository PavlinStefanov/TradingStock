using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingStock.Business.CQRS.Commands;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.Commands;

namespace TradingStock.Api.WebApi.Controllers.Stocks
{
    [Produces("application/json")]
    [Route("api/stocks")]
    public class AddStockController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;

        public AddStockController(ICommandDispatcher commandDispatcher, IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("createStock")]
        public IActionResult CreateStock()
        {
            var createCommand = new CreateStockCommand(Guid.NewGuid(), -1, "Gold", 0.221, 3.454);
            _commandDispatcher.DispatchCommand(createCommand);

            return new OkObjectResult("OK");
        }
    }
}