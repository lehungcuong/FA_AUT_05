using Final_HienNTN;
using System;
using System.Configuration;
using static Final_HienNTN.Browers;

namespace Auto.Test
{
    public class BaseTest:IDisposable
    {
        public Browers browsers;

        public BaseTest()
        {
            browsers = new Browers(GetBrowserType(), GetBrowserURL());
        }
        /// <summary>
        /// Get and return Browser type from App.config
        /// </summary>
        /// <returns>Browser type</returns>
        public BrowserType GetBrowserType()
        {
            string app = GetValueConfig().AppSettings.Settings["browser"].Value;
            Enum.TryParse(app, out BrowserType type);
            return type;
        }

        /// <summary>
        /// Get and return URL from App.config
        /// </summary>
        /// <returns>url</returns>
        public string GetBrowserURL()
        {
            var url = GetValueConfig().AppSettings.Settings["uri"].Value;
            return url;
        }
        /// <summary>
        /// Get Value Config from App.config
        /// </summary>
        /// <returns>configuration</returns>
        public static Configuration GetValueConfig()
        {
            var filePath = @"C:\Users\ASUS\source\repos\Final_HienNTN\Final_HienNTN\App.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return configuration;
        }
        /// <summary>
        /// Close driver when testcase close
        /// </summary>
        public void Dispose()
        {
            browsers.driver.Quit();
        }
    }
}
