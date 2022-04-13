using System;
using System.Data.SqlClient;
using CurrencyPriceLogger.Common;
using CurrencyPriceLogger.Utilities;

namespace CurrencyPriceLogger.Controllers
{
    class DatabaseController
    {
        public static void ConnectToDatabase(Config config)
        {
            string connectionString = @config.Data.ConnectionString;
            Logger.Log("Connecting to database...");

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    Logger.Log("Connection to database successful.");
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Error occured: " + ex.Message);
                Environment.Exit(2);
            }
        }
    }
}
