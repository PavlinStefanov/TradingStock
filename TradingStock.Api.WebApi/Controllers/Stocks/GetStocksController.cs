using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.Queries;

namespace TradingStock.Api.WebApi.Controllers.Stocks
{
    [Produces("application/json")]
    [Route("api/stocks")]
    public class GetStocksController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        public GetStocksController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var query = new StockByTypeQuery("Gold");
            var stocksResult = _queryProcessor.Process(query);
            return new string[] { "value1", "pavlin" };
        }

    }
}