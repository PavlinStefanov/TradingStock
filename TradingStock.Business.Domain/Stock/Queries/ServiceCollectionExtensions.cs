using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Queries;
using TradingStock.Business.Domain.Stock.DatatransferObjects;

namespace TradingStock.Business.Domain.Stock.Queries
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IHandleQuery<StockByTypeQuery, IEnumerable<StockByTypeDto>>, StockByTypeQueryHandler>();

            return services;
        }
    }
}
