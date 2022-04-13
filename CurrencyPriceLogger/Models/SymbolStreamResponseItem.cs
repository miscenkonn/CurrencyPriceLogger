using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyPriceLogger.Models
{
    public class SymbolStreamResponseItem
    {
        public ulong u { get; set; }
        public string s { get; set; }
        public string b { get; set; }
        public string B { get; set; }
        public string a { get; set; }
        public string A { get; set; }
    }
}
