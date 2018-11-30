using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.Queries;
using TradingStock.Infrastructure.Context;

namespace TradingStock.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IQueryProcessor _queryProcessor;

        public ValuesController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var query = new StockByTypeQuery("Gold");
            var stocksResult = _queryProcessor.Process(query);
           
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
