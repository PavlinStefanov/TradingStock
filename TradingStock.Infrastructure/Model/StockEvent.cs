using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TradingStock.Infrastructure.Model
{
    [Table("StockEvent")]
    public class StockEvent : DbContext
    {
        [Key, Column("AggregateId", Order = 0, TypeName = "uniqueidentifier")]
        public Guid AggregateId { get; set; }

        [Column("EventId", Order = 1, TypeName = "uniqueidentifier")]
        public Guid EventId { get; set; }

        [Column("EventType", Order = 2, TypeName = "nvarchar(100)")]
        public string EventType { get; set; }

        [Column("Version", Order = 3, TypeName = "int")]
        public int Version { get; set; }

        [Column("TimeStamp", Order = 4, TypeName = "datetimeoffset(7)")]
        public DateTimeOffset TimeStamp { get; set; }
    }
}
