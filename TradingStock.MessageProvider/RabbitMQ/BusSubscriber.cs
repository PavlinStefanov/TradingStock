using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradingStock.MessageProvider.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace TradingStock.MessageProvider.RabbitMQ
{
    public class BusSubscriber : IInterProcessBusSubscriber, IDisposable
    {
        private readonly string _busName;
        private readonly string _connectionString;
        private CancellationTokenSource _cancellationToken;
        private Task _workerTask;
        private ISubject<string> _eventsSubject = new Subject<string>();

        public BusSubscriber()
        {
            _busName = "InterProcessBus";
            _connectionString = "";

        }

        /// <summary>
        /// 
        /// </summary>
        private void StartManagerListener()
        {
            _cancellationToken = new CancellationTokenSource();
            _workerTask = Task.Factory.StartNew(() => ListenForMessage(), _cancellationToken.Token);
        }


        /// <summary>
        /// 
        /// </summary>
        private void ListenForMessage()
        {
            //var factory = new ConnectionFactory
            //{
            //    HostName = "localhost", //_connectionString,
            //    UserName = "pavlin",
            //    Password = "pavlin",
            //    VirtualHost = "/",
            //    AutomaticRecoveryEnabled = true,
            //    RequestedHeartbeat = 60
            //};
            var connectionFactory = new ConnectionFactory();
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            config.GetSection("RabbitMqConnection").Bind(connectionFactory);

            
            using (IConnection connection = connectionFactory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(_busName, "fanout");
                    bool durable = true;
                    bool exclusive = false;
                    bool autoDelete = false;

                    var queue = channel.QueueDeclare(Assembly.GetEntryAssembly().GetName().Name, durable, exclusive, autoDelete, null);
                    var consumer = new QueueingBasicConsumer(channel);

                    channel.BasicConsume(queue.QueueName, false, string.Empty, consumer);

                    while (true)
                    {
                        if (_cancellationToken.IsCancellationRequested)
                            break;

                        BasicDeliverEventArgs deliverEventArgs;
                        consumer.Queue.Dequeue(10, out deliverEventArgs);

                        if (deliverEventArgs == null)
                            continue;

                        var message = Encoding.ASCII.GetString(deliverEventArgs.Body);

                        Task.Run(async () =>
                        {
                            await Task.Run(() =>
                            {
                                _eventsSubject.OnNext(message);
                            });
                        });

                        channel.BasicAck(deliverEventArgs.DeliveryTag, false);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<string> GetEventStream()
        {
            return _eventsSubject.AsObservable();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CancelWorkerTask()
        {
            if (_workerTask == null)
                return;

            _cancellationToken.Cancel();
            _workerTask.Wait();
            _workerTask.Dispose();
        }

        public void Dispose()
        {
            CancelWorkerTask();
        }
    }
}
