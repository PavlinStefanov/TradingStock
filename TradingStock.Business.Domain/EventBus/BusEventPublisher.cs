using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TradingStock.Business.CQRS.Events;
using TradingStock.Business.Domain.Stock.Events;

namespace TradingStock.Business.Domain.EventBus
{
    public class BusEventPublisher : IEventPublisher
    {
        private IEnumerable<IBusEventHandler> _eventHandlers;
        private Dictionary<Type, MethodInfo> _eventMethods = new Dictionary<Type, MethodInfo>();

        public BusEventPublisher(IEnumerable<IBusEventHandler> eventHandlers)
        {
            _eventHandlers = eventHandlers;
            FetchEventMethods(_eventHandlers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_eventHandlers"></param>
        private void FetchEventMethods(IEnumerable<IBusEventHandler> eventHandlers)
        {
            foreach (var handler in eventHandlers)
            {
                var handlerMethod = (from method in handler.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                     let _params = method.GetParameters()
                                     where _params.Count() == 1 && method.Name.Contains("Handle")
                                     select new
                                     {
                                         EventType = _params.First().ParameterType,
                                         Method = method
                                     }).FirstOrDefault();

                if (handlerMethod != null)
                    _eventMethods.Add(handlerMethod.EventType, handlerMethod.Method);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        public void Publish<T>(T @event) where T : IEvent
        {
            var handler = _eventHandlers.SingleOrDefault(x => x.HandlerType == @event.GetType());
            if (handler == null)
                throw new Exception($"Unable to find Handler for {@event.GetType().Name}.");

            Task.Run(() =>
            {
                _eventMethods[@event.GetType()].Invoke(handler, new[] { (object)@event });
            }).Wait();
        }
    }
}
