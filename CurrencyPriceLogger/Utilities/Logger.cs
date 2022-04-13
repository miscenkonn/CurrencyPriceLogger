using System;

namespace CurrencyPriceLogger.Utilities
{
    class Logger
    {
        public static void Log(string s)
        {
            Console.WriteLine("{0}: {1}", DateTime.Now, s);
        }
    }
}
