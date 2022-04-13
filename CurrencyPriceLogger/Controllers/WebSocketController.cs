using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Binance.Spot;
using Newtonsoft.Json;
using CurrencyPriceLogger.Common;
using CurrencyPriceLogger.Models;
using CurrencyPriceLogger.Utilities;
using CurrencyPriceLogger.Helpers;
using CurrencyPriceLogger.Database;
using System.Net.NetworkInformation;

namespace CurrencyPriceLogger.Controllers
{
    class WebSocketController
    {
        SymbolBookData parsedItem { get; set; }
        List<SymbolBookData> dataBuffer { get; set; }
        MarketDataWebSocket webSocket { get; set; }
        DateTime writeTimer { get; set; }
        DateTime connectivityTimer { get; set; }

        public async Task InitializeWebSocket(Config config)
        {
            dataBuffer = new List<SymbolBookData>();

            List<string> streams = new List<string>();

            foreach (var s in config.Data.Symbols)
            {
                string newStream = s + "@bookTicker";
                streams.Add(newStream);
            }

            await Connect(streams.ToArray(), config);
        }

        public async Task Connect(string[] streams, Config config)
        {
            try
            {
                Logger.Log("Connecting to the Binance API...");

                webSocket = new MarketDataWebSocket(streams);

                connectivityTimer = writeTimer = DateTime.Now;

                webSocket.OnMessageReceived(async (data) =>
                {
                    dynamic receivedItem = JsonConvert.DeserializeObject(@data);
                    if (receivedItem != null && receivedItem.data != null)
                    {
                        parsedItem = ParsingHelper.GenerateSymbolData(receivedItem.data);
                        dataBuffer.Add(parsedItem);
                    }

                    if ((DateTime.Now - writeTimer).TotalMilliseconds >= Constants.WRITE_INTERVAL)
                    {
                        writeTimer = DateTime.Now;

                        Logger.Log("Data buffer is full.");
                        Logger.Log("Push to database is running...");

                        using (var context = new SymbolContext())
                        {
                            try
                            {
                                var tmpBuffer = dataBuffer;
                                context.Symbols.AddRange(tmpBuffer);
                                await context.SaveChangesAsync();
                                Logger.Log("Wiping buffer data...");
                                dataBuffer.Clear();
                            }
                            catch (Exception ex)
                            {
                                Logger.Log("Error writing to database: " + ex.Message);
                            }
                        }

                        Logger.Log("Buffering is in progress...");
                    }
                }, CancellationToken.None);

                await webSocket.ConnectAsync(CancellationToken.None);
                Logger.Log("Connection to API successful.");
                Logger.Log("Buffering is in progress...");

                while (true)
                {
                    if ((DateTime.Now - connectivityTimer).TotalMilliseconds >= Constants.CONNECTIVITY_CHECK_INTERVAL)
                    {
                        try
                        {
                            Ping myPing = new Ping();
                            String host = "google.com";
                            byte[] buffer = new byte[32];
                            int timeout = 1000;
                            PingOptions pingOptions = new PingOptions();
                            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                            if (reply.Status != IPStatus.Success)
                            {
                                Logger.Log("Connection lost...");
                                Logger.Log("Trying to reconnect in 3 seconds... ");
                                Thread.Sleep(3000);
                                await Connect(streams, config);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log("Connection lost...");
                            Logger.Log("Trying to reconnect in 3 seconds... ");
                            Thread.Sleep(3000);
                            await Connect(streams, config);
                        }
                        connectivityTimer = DateTime.Now;
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Log("Error occured: " + ex.Message);
                Logger.Log("Trying to reconnect in 3 seconds... ");
                Thread.Sleep(3000);
                await Connect(streams, config);
            }
        }
    }
}
