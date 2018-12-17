using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Commands
{
    public interface ICommandPrecondition<in TCommand> where TCommand : ICommand
    {
        CommandPreconditionCheckResult Check(TCommand command);
    }
}
