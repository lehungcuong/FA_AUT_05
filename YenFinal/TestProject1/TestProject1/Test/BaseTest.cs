using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using TestProject1.ReportHelper;
using TestProject2.WebDriver.WebDriver;
using Xunit;
using static TestProject2.WebDriver.WebDriver.BrowserFactory;

namespace TestProject1.Test
{
    public class BaseTest : IDisposable, IClassFixture<ExtentReportsHelper>
    {

        public BrowserFactory browserFactory;
        public static Configuration getConfiguration;
        public BaseTest()
        {

            getConfiguration = GetValueConfig();
            browserFactory = new BrowserFactory(GetBrowserTypeByJson(), GetBrowserUrl());

        }

        /// <summary>
        /// Get the Browser's url
        /// </summary>
        /// <returns></returns>
        public string GetBrowserUrl()
        {
            return getConfiguration.AppSettings.Settings["uri"].Value;
        }

        /// <summary>
        /// Get the type of browser 
        /// </summary>
        /// <returns></returns>
        public static BrowserType GetBrowserTypeByConfig()
        {

            string BrowserName = getConfiguration.AppSettings.Settings["browser"].Value;
            Enum.TryParse(BrowserName, out BrowserType type);
            return type;
        }


        /// <summary>
        /// Get Value Config
        /// </summary>
        /// <returns></returns>
        public static Configuration GetValueConfig()
        {

            string pathConfig = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Config\testhost.dll.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = pathConfig };
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }
        /// <summary>
        /// Get Browser Type By Json/lay browser tu file json
        /// </summary>
        /// <returns></returns>
        public static BrowserType GetBrowserTypeByJson()
        {
            //Directory.GetCurrentDirectory bin
            using (StreamReader file = File.OpenText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Json\jsconfig1.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //Deserialize reads the Json file, Saves it to an object of type BrowserJson
                BrowserJSon Browserjson = serializer.Deserialize(file, typeof(BrowserJSon)) as BrowserJSon;
                Enum.TryParse(Browserjson.browser, out BrowserType type);
                return type;
            }
        }
        public class BrowserJSon
        {
            //Name of browser same as key in file json
            public string browser { get; set; }
        }
        /// <summary>
        /// Method to release resources
        /// </summary>
        public void Dispose()
        {
            Thread.Sleep(5000);
            browserFactory.driver.Quit();
        }
    }
}
