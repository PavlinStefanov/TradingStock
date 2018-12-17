using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Commands
{
    [Serializable]
    public class Command : ICommand
    {
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }

        //public Command(Guid id, int version)
        //{
        //    Id = id;
        //    ExpectedVersion = version;
        //}
    }
}
