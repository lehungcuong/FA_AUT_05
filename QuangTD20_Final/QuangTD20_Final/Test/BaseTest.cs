using System;
using QuangTD20_Final1;
using static QuangTD20_Final1.Browser;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;

namespace QuangTD20_Final.Test
{
    public class Basetest : IDisposable
        {

            public BrowserFactory browserFactory;

            public Basetest()
            {

                browserFactory = new BrowserFactory(GetBrowserType(), URL());
            }

        // read Browser in file Testhost.Dll.config
        public BrowserType GetBrowserType()
        {
            var Testhost = GetValueJson("Browser");
            Enum.TryParse(Testhost, out BrowserType type);
            return type;
        }
        // Url in file readjon.Json
        public string URL()
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
