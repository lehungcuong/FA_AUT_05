using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using DriverFactory.WebDriver;
using Newtonsoft.Json;
using static DriverFactory.WebDriver.BrowserFactory;

namespace TestPOM.Test
{

    public class BaseTest : IDisposable
    {
        //public IWebDriver driver;
        public BrowserFactory browserFactory;

        public BaseTest()
        {
            // Innitialize browser with param from GetBrowserType function
            browserFactory = new BrowserFactory(GetBrowserType(), URL());
        }

        public BrowserType GetBrowserType()
        {
            // Read browser and Change type string to enum of browserType
            var Testhost = GetValueJson("browser");
            Enum.TryParse(Testhost, out BrowserType type);
            return type;
        }

        public string URL()
        {
            var Url = ConfigurationManager.AppSettings["Url"].ToString();
            return Url;
        }

        public string FullPathJson()
        {
            // Get and return JSON File path
            string pathfolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPathfile = pathfolder + @"\readjson.json";
            return fullPathfile;
        }

        private Dictionary<string, string> ReadJSon()
        {
            // Read JSON file
            string json_file = File.ReadAllText(FullPathJson());
            Dictionary<string, string> json_dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json_file);
            return json_dict;
        }

        public string GetValueJson(string key)
        {
            // Return JSON file results
            return ReadJSon()[key];
        }

        public void Dispose()
        {
            // Close all windown
            browserFactory.Driver.Quit();
        }
    }
}
