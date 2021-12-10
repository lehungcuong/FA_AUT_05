using static DriverFactory.BrowserFactory;

namespace LoiDV4_Final.Common
{
    public class JSONConfig
    {
        public BrowserType browser { get; set; }
        public string url { get; set; }
        public JSONConfig(BrowserType browserName, string url)
        {
            browser = browserName;
            this.url = url;
        }
    }
}
