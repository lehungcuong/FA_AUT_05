using LuanNHB_Final.Helper;
using System;
using System.Configuration;
using System.IO;
using WebDriverFactory;
using static WebDriverFactory.Browser;

namespace LuanNHB_Final.Test
{
    public class BaseTest : IDisposable
    {
        public enum FileTypes { Json, Config }

        public BrowserFactory browserFactory;
        public JsonHelper jsonHelper;

        public BaseTest()
        {
            jsonHelper = new JsonHelper();
            browserFactory = LoadFileByType(GetFileTypeBy("Json"));
        }
        /// <summary>
        /// Choose File By Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public BrowserFactory LoadFileByType(FileTypes type)
        {

            switch (type)
            {
                case FileTypes.Json:
                    browserFactory = new BrowserFactory(GetBrowserTypeByJson(jsonHelper.GetValue("Browser")), jsonHelper.GetValue("Url"));
                    return browserFactory;
                    break;
                case FileTypes.Config:
                    browserFactory = new BrowserFactory(GetBrowserType(), GetBrowserURL());
                    return browserFactory;
                    break;
                default: throw new Exception("Please enter Json or ConfigType ");
            }
            return browserFactory;
        }
        /// <summary>
        /// get File Type
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FileTypes GetFileTypeBy(String value)
        {
            Enum.TryParse(value, out FileTypes type);
            return type;
        }

        /// <summary>
        /// stranfer string data to BrowserType Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BrowserType GetBrowserTypeByJson(String value)
        {
            Enum.TryParse(value, out BrowserType type);
            return type;
        }

        /// <summary>
        /// get string data from config file and stranfer to BrowserType Emun
        /// </summary>
        /// <returns></returns>
        public static BrowserType GetBrowserType()
        {
            string testHost = GetValueConfig().AppSettings.Settings["Browser"].Value;
            Enum.TryParse(testHost, out BrowserType type);
            return type;
        }

        /// <summary>
        /// get Url from config
        /// </summary>
        /// <returns></returns>
        public static string GetBrowserURL()
        {
            string Url = GetValueConfig().AppSettings.Settings["Uri"].Value;
            return Url;
        }

        /// <summary>
        /// set direct path for configuration
        /// </summary>
        /// <returns></returns>
        public static Configuration GetValueConfig()
        {
            var filePath = Directory.GetCurrentDirectory() + @"\Config\App.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            return configuration;
        }



        public void Dispose()
        {
            // BrowserFactory.Driver.Quit();


        }
    }
}
