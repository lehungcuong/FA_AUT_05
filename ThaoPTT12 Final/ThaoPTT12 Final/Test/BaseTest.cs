using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriver;
using Xunit;

namespace ThaoPTT12_Final.Test
{
    public class BaseTest : IDisposable
    {
        public IWebDriver driver;
        public BrowserFactory browerFactory;
    
        public BaseTest()
        {
            browerFactory = new BrowserFactory(GetBrowerType(), GetValueJson("Url"));
            driver = browerFactory.Driver;
        }
        public BrowserType GetBrowerType()
        {
            var browerType = GetValueJson("browser");
            Enum.TryParse(browerType, out BrowserType type);
            return type;
        }

        //public string GetBrowerURL()
        //{
        //    string Url = ConfigurationManager.AppSettings["Url"].Value;
        //    return Url;
        //}

        public static string FullPathJson()
        {
            string pathfolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPathfile = pathfolder + @"\Configtest.json";
            return fullPathfile;
        }

        //read file Json and save file in Dictionary<string, string>
        public static Dictionary<string, string> ReadJSon()
        {
            string json_file = File.ReadAllText(FullPathJson());
            Dictionary<string, string> json_dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json_file);
            return json_dict;
        }
        
        public static string GetValueJson(string key)
        {
            return ReadJSon()[key];
        }

        public void Dispose()
        {
            Thread.Sleep(2000);
            browerFactory.Driver.Quit();
        }
    }
}
