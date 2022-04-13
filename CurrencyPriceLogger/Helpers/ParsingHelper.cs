using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyPriceLogger.Models;

namespace CurrencyPriceLogger.Helpers
{
    class ParsingHelper
    {
        public static SymbolBookData GenerateSymbolData(dynamic item)
        {
            SymbolBookData newSymbolData = new SymbolBookData();

            newSymbolData.OrderBookUpdateId = item.u;
            newSymbolData.Symbol = item.s;
            newSymbolData.BestBidPrice = item.b;
            newSymbolData.BestBidQuantity = item.B;
            newSymbolData.BestAskPrice = item.a;
            newSymbolData.BestAskQuantity = item.A;
            newSymbolData.LogTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss:fff");

            return newSymbolData;
        }
    }
}
