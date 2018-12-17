using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradingStock.Business.CQRS.Commands
{
    public interface IAsyncCommandHandler
    { }

    public interface IAsyncCommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface IAsyncCommandHandler<in TCommand, TResult> : ICommandHandler where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
