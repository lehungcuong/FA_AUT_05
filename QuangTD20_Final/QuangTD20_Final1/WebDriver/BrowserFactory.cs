using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using static QuangTD20_Final1.Browser;

namespace QuangTD20_Final1
{
    public class BrowserFactory
    {
       
        public IWebDriver Driver;
        public Browser browser; 
        
        // khoi tao 
        public BrowserFactory(BrowserType type, string url )
        {

            Driver = GetIWebDriver(type, url );
        }

        public string Title { get; set; }

        public static IWebDriver GetIWebDriver (BrowserType type, string url )
        {
            IWebDriver Driver;
            string driverFolder = @"C:\Users\Quang\source\repos\QuangTD20_Final\QuangTD20_Final1\WebDriver\" + $"{type}";
            switch (type)
            {
                // BrowserType is Chrome
                case BrowserType.Chrome:
                   
                    Driver = new ChromeDriver(driverFolder);
                   
                    break;
                // BrowserType is Firefox
                case BrowserType.Firefox:
                    Driver = new FirefoxDriver(driverFolder);
                    
                    break;
                default: throw new Exception(" Input Browsers are Chrome or Firefox");
            }
            Driver.Url = url;
            return Driver;
        }
    }
}
