using System;
using CurrencyPriceLogger.Controllers;
using CurrencyPriceLogger.Utilities;
using CurrencyPriceLogger.Common;

namespace CurrencyPriceLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log("Currency Price Logger has been started.");

            Config config = new Config();
            WebSocketController webSocket = new WebSocketController();

            DatabaseController.ConnectToDatabase(config);
            webSocket.InitializeWebSocket(config).Wait();

            Console.ReadLine();
        }
    }
}
