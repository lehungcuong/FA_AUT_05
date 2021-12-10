using System;
using System.Configuration;
using System.IO;

namespace XUnitTest_POM.Constraints
{
    class ConfigHelper
    {
        private readonly static string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly static string ConfigPath = path + @"\Config\app.config";

        /// <summary>
        /// Get configuaration path
        /// </summary>
        /// <returns> configuration </returns>
        public static Configuration GetConfigurationPath()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = ConfigPath };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return configuration;
        }

        /// <summary>
        /// Get value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            string value = GetConfigurationPath().AppSettings.Settings[key].Value;
            return value;
        }

        /// <summary>
        /// Return URL from App.config
        /// </summary>
        /// <returns> url </returns>
        public static string BrowserURL()
        {
            var url = ConfigurationManager.AppSettings["uri"].ToString();
            return url;
        }
    }
}
