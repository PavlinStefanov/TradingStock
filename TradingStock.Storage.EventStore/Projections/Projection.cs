using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Storage.EventStore.Projections
{
    public class Projection
    {
        public Projection(string name, string status)
        {
            Name = name;
            Status = status;
        }
        public string Name { get; private set; }
        public string Status { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Status: {1}", Name, Status);
        }
    }
}
