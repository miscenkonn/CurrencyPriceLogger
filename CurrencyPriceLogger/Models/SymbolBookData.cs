using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CurrencyPriceLogger.Models
{
    public class SymbolBookData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public ulong OrderBookUpdateId { get; set; }
        public string Symbol { get; set; }
        public string BestBidPrice { get; set; }
        public string BestBidQuantity { get; set; }
        public string BestAskPrice { get; set; }
        public string BestAskQuantity { get; set; }
        public string LogTime { get; set; }
    }
}
