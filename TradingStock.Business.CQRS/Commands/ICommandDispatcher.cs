using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TradingStock.Business.CQRS.Commands
{
    public interface ICommandDispatcher
    {
        void DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand;
        Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
        TReturn DispatchCommand<TCommand, TReturn>(TCommand command) where TCommand : ICommand;
        Task<TReturn> DispatchCommandAsync<TCommand, TReturn>(TCommand command) where TCommand : ICommand;
    }
}
