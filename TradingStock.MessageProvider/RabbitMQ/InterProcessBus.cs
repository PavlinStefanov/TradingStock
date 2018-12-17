using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Text;

namespace TradingStock.MessageProvider.RabbitMQ
{
    public class InterProcessBus : IInterProcessBus
    {
        private readonly string _busName;

        public InterProcessBus()
        {
            _busName = "InterProcessBus";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            var config = GetRabbitMqConnectionProperties();
            
            var connectionFactory = new ConnectionFactory();
            config.GetSection("RabbitMqConnection").Bind(connectionFactory);

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var bytes = Encoding.ASCII.GetBytes(message);
                   
                    channel.ExchangeDeclare(_busName, "fanout");
                    channel.BasicPublish(_busName, string.Empty, null, bytes);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IConfigurationRoot GetRabbitMqConnectionProperties()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                return config;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get connection properties for RabbitMQ", ex);
            }
        }
    }
}
