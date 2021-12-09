using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Collections.Specialized;
using TestPOM2;
using static TestPOM2.Browser;
using System.Collections.Generic;
using System.IO;


namespace TestPOM.Test 
{

    public class Basetest : IDisposable
    {

        
        public BrowserFactory browserFactory;
        
       

        public Basetest()
        {
           // driver = new ChromeDriver();
           // driver.Url = "https://phptravels.net/";
           // browserFactory = new BrowserFactory(GetBrowserType());         
           // browserFactory = new BrowserFactory(GetBrowserType(), URL());         
        }

        
        /*
        // read Browser in file Testhost.Dll.config
          public BrowserType GetBrowserType()
          {
              string Testhost = ConfigurationManager.AppSettings["Browser"].ToString();
              Enum.TryParse(Testhost, out BrowserType type);
              return type;
          }

          // read Url in file Testhost.Dll.config
        
        
          public string URL()
          {
              string url = ConfigurationManager.AppSettings["Url"].ToString();
              return url;
          }
          */

        //  BrowserType in file readjon.Json
       public BrowserType GetBrowser()
        {
            var Testhost = GetValueJson("browser");
            Enum.TryParse(Testhost, out BrowserType type);
            return type;
        }
        // Url in file readjon.Json
        public string URL1()
        {
            var Url = GetValueJson("Url");
            return Url;
        }


        // path parent (thu muc chua file Json) file Json and file Json  
        public string FullPathJson()
        {
            string pathfolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fullPathfile = pathfolder + @"\readjson.json";
            return fullPathfile;
        }

        //read file Json and save file in Dictionary<string, string>
        private Dictionary<string, string> ReadJSon()
        {
            string json_file = File.ReadAllText(FullPathJson());
            Dictionary<string, string> json_dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json_file);
            return json_dict;
        }
        // 
        public string GetValueJson(string key)
        {
            return ReadJSon()[key];
        }

      
                   
        public void Dispose()
        {
            browserFactory.Driver.Quit();
        }

    }

}
