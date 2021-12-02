using System;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;

namespace XunitPOM.Utilities
{
    public class ConfigHelper
    {
        private readonly static string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private readonly static string ConfigPath = SolutionPath + @"\Config\testhost.config";
        
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
