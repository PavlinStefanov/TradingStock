using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Commands;

namespace TradingStock.Business.Domain.Stock.Commands
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            
            services.AddScoped<ICommandHandler<CreateStockCommand>, CreateStockCommandHandler>();

            return services;
        }
    }
}
