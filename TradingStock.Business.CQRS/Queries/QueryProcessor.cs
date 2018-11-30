using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace TradingStock.Business.CQRS.Queries
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceProvider _serviceProvider;
        //private readonly ILogger _logger;

        public QueryProcessor(IServiceProvider serviceProvider)
        {
            //_logger = loggerFactory.CreateLogger<QueryProcessor>();
            _serviceProvider = serviceProvider;
        }

        [DebuggerStepThrough]
        public TResult Process<TResult>(IQuery<TResult> query)
        {
            //_logger.LogDebug($"Processing query {query}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetService(handlerType);
            var queryResult = handler.Execute((dynamic)query);

            stopwatch.Stop();
            //_logger.LogInformation($"Execution time for query {query}: {stopwatch.Elapsed.ToString("g")}");
            return queryResult;
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            //_logger.LogDebug($"Processing query {query}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var handlerType = typeof(IQueryHandlerAsync<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetService(handlerType);
            var queryResult = await handler.ExecuteAsync((dynamic)query).ConfigureAwait(false);

            stopwatch.Stop();
            //_logger.LogInformation($"Execution time for query {query}: {stopwatch.Elapsed.ToString("g")}");
            return queryResult;
        }
    }
}
