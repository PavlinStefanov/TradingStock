using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Storage.EventStore.Storage;

namespace TradingStock.Storage.EventStore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventStore(this IServiceCollection services)
        {
            services.AddScoped<IEventStorage, EventStorage>();
            
            return services;
        }
    }
}
