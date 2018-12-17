using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Messages
{
    public interface IHandler<T> where T : IMessage
    {
        void Handle(T message);
    }
}
