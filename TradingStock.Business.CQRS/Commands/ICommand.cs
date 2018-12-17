using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Business.CQRS.Messages;

namespace TradingStock.Business.CQRS.Commands
{
    public interface ICommand : IMessage
    {
        Guid Id { get; set; }
        int ExpectedVersion { get; set; }
    }
}
