using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POM_Driver.BrowserFactory;

namespace QuyenLLP_FinalTest.Utilities
{
    public class ReadConfig
    {
        static string fileConfigPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Config\testhost.config";

        /// <summary>
        /// Get configuaration path
        /// </summary>
        /// <returns></returns>
        public Configuration GetValueConfig()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = fileConfigPath };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return configuration;
        }

        /// <summary>
        /// Get Browser Type in config file
        /// </summary>
        /// <returns></returns>
        public BrowserType GetBrowserType()
        {
            string BrowserName = GetValueConfig().AppSettings.Settings["browserName"].Value;
            Enum.TryParse(BrowserName, out BrowserType type);
            return type;
        }
        /// <summary>
        /// Get Start Url in config file
        /// </summary>
        /// <returns></returns>
        public string GetStartUrl()
        {
            var url = GetValueConfig().AppSettings.Settings["startUrl"].Value;
            return url;
        }
        /// <summary>
        /// Get Email for Login in config file
        /// </summary>
        /// <returns></returns>
        public string GetEmailLogin()
        {
            var email = GetValueConfig().AppSettings.Settings["emailLogin"].Value;
            return email;
        }
        /// <summary>
        /// Get PassWord for login in config file
        /// </summary>
        /// <returns></returns>
        public string GetPassWord()
        {
            var pass = GetValueConfig().AppSettings.Settings["password"].Value;
            return pass;
        }
    }
}
