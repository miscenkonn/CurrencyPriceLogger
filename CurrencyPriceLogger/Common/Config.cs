using System;
using System.IO;
using SharpYaml.Serialization;
using CurrencyPriceLogger.Utilities;

namespace CurrencyPriceLogger.Common
{
    class Config
    {
        public class YamlData
        {
            public string ConnectionString { get; set; }
            public string[] Symbols { get; set; }
        }
        public YamlData Data { get; set; }
        public Config()
        {
            var yamlConfigPath = "config.yaml";
            var input = new StreamReader(yamlConfigPath);
            var deserializer = new Serializer();
            Data = (YamlData)deserializer.Deserialize(input, typeof(YamlData));

            Logger.Log("Total symbols count: " + Data.Symbols.Length);

            Validate();
            
            foreach (var s in Data.Symbols)
            {
                Logger.Log(s);
            }
        }
        public void Validate()
        {
            if (string.IsNullOrEmpty(Data.ConnectionString))
            {
                Logger.Log("Connection string is wrong! Please, check your connection string.");
                Environment.Exit(1);
            }
            else if (Data.Symbols.Length <= 0)
            {
                Logger.Log("No symbols were specified! Please, specify at least one symbol to start logging.");
                Environment.Exit(1);
            }
        }
    }
}
