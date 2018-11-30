using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingStock.Infrastructure.Model
{
    [Table("Stocks")]
    public class Stock
    {
        [Key, Column("Id", Order = 0, TypeName = "uniqueidentifier")]
        public Guid ID { get; set; }

        [Column("StockType", Order = 1, TypeName = "nvarchar(50)")]
        public string StockType { get; set; }

        [Column("Up", Order = 2, TypeName = "float")]
        public double? Up { get; set; }

        [Column("Down", Order = 3, TypeName = "float")]
        public double? Down { get; set; }

        [Column("StockChange", Order = 4, TypeName = "datetime")]
        public DateTime StockChange { get; set; }
    }
}
