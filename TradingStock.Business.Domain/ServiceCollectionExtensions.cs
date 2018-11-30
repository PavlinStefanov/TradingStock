using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.DatatransferObjects;
using TradingStock.Business.Domain.Stock.Queries;

namespace TradingStock.Business.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStockQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IQueryProcessor, QueryProcessor>();
            services.AddTransient<IQueryHandler<StockByTypeQuery, IEnumerable<StockByTypeDto>>, StockByTypeQueryHandler>();

            return services;
        }
    }
}
