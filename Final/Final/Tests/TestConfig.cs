using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace Final.Tests
{
    public class TestConfig
    {
        public static string Browser { get; set; }

        /// <summary>
        /// Return Browser in file Config
        /// </summary> 
        static TestConfig()
        {
            Browser = ConfigurationManager.AppSettings.Get("ChromeBrowser");
        }

        /// <summary>
        /// Return browser in file JSon 
        /// </summary>
        /// <returns></returns>
        public static string TestJSon()
        {
            using (StreamReader file = File.OpenText(@"TestData\App.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                BrowserJSon? Browserjson = serializer.Deserialize(file, typeof(BrowserJSon)) as BrowserJSon;
                return Browserjson.Chrome;
            }
        }
    }

    public class BrowserJSon
    {
        public string? Chrome { get; set; }
        public string? FireFox { get; set; }
    }
}
