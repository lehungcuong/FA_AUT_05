using Project1.WebDriver;
using System;
using System.Configuration;
using static Project1.WebDriver.Browser;

namespace DemoPOM.Test
{
    public abstract class BaseTest : IDisposable
    {
        public Browser browser;
        public BaseTest()
        {
            // Innitialize browser with param from GetBrowserType function
            browser = new Browser(GetBrowserType());
            // Get url from test host config file
            var url = ConfigurationManager.AppSettings["uri"].ToString();
            // Go to page with this url
            Browser.GoToPage(url);
        }

        public BrowserType GetBrowserType()
        {
            // Read browser from configuration file
            var browserType = ConfigurationManager.AppSettings["browser"].ToString();
            // Change type string to enum of browserType
            Enum.TryParse(browserType, out BrowserType type);
            return type;
        }

        public void Dispose()
        {
            // Close all windown
            Browser.Driver.Close();
            Browser.Driver.Quit();
        }
    }
   
}
