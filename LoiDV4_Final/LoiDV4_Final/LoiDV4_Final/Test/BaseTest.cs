using DriverFactory;
using LoiDV4_Final.Common;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using static DriverFactory.BrowserFactory;

namespace LoiDV4_Final.Test
{
    public class BaseTest : IDisposable
    {
        public BrowserFactory browser;
        static string pathConfig = @"\FileConfig\AppConfig.config";
        public JSONConfig config;
        static Configuration GetConfiguration;

        public BaseTest()
        {
            if (pathConfig.Contains("json"))
            {
                config = ReadJSONConfig.GetConfig(pathConfig);
                browser = new BrowserFactory(config.browser);
                BrowserFactory.Driver.Url = config.url;

            }
            else
            {
                GetConfiguration = GetValueConfig();
                string url = GetConfiguration.AppSettings.Settings["uri"].Value;

                browser = new BrowserFactory(GetBrowserType());
                BrowserFactory.Driver.Url = url;
            }

        }

        /// <summary>
        /// Get browser type file config 
        /// </summary>
        /// <returns></returns>
        public BrowserType GetBrowserType()
        {
            string BrowserName = GetConfiguration.AppSettings.Settings["browser"].Value;
            Enum.TryParse(BrowserName, out BrowserType type);
            return type;
        }


        /// <summary>
        /// Use file path to point to config file
        /// </summary>
        /// <returns></returns>
        public static Configuration GetValueConfig()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + pathConfig;
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = path };
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        public void Dispose()
        {
            Thread.Sleep(5000);
            BrowserFactory.Driver.Quit();
        }
    }
}
