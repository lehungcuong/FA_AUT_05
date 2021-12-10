using System;
using System.Configuration;

namespace Xunit.DriverFactory.Utilities
{
    public class ConfigHelper
    {
        private readonly static string ConfigPath = DataConstant.BinPath + @"\Config\testhost.config";

        /// <summary>
        /// Get configuaration path
        /// </summary>
        /// <returns></returns>
        public static Configuration GetConfigurationPath()
        {
            try
            {
                var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = ConfigPath };
                var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                return configuration;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        /// <summary>
        /// Get value by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            try
            {
                string value = GetConfigurationPath().AppSettings.Settings[key].Value;
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
