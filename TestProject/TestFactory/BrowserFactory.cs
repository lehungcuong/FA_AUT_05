using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using static TestFactory.Browser;

namespace TestFactory
{
    public class BrowserFactory
    {
        public IWebDriver Driver;
        private static readonly string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

        public BrowserFactory(string type, string url)
        {
            Driver = GetWebDriver(type, url);
        }

        public static IWebDriver GetWebDriver(string type, string url)
        {
            IWebDriver driver;
            string driverFolder = SolutionPath + @"\TestFactory\" + $"{type}";
            BrowserType driverType = type.Equals("Chrome") ? BrowserType.Chrome : BrowserType.FireFox;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            switch (driverType)
            {
                case BrowserType.Chrome:
                    options.AddArguments("--disable-dev-shm-usage");
                    driver = new ChromeDriver(driverFolder, options);
                    break;
                case BrowserType.FireFox:
                    driver = new FirefoxDriver(driverFolder);
                    break;
                default:
                    driver = new ChromeDriver(driverFolder, options);
                    break;
            }
            driver.Url = url;
            return driver;
        }
    }
    public class Browser
    {
        public enum BrowserType
        {
            Chrome, FireFox
        }
    }
}
