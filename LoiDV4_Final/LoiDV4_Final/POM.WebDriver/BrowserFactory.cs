using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;


namespace DriverFactory
{
    public class BrowserFactory
    {
        public static IWebDriver Driver;
        public BrowserFactory(BrowserType type)
        {
            Driver = GetWebDriver(type);
        }

        /// <summary>
        /// Define browser type
        /// </summary>
        public enum BrowserType
        {
            Chrome, FireFox
        }

        /// <summary>
        /// Get type webdriver
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static IWebDriver GetWebDriver(BrowserType type)
        {
            IWebDriver Driver = null;
            string DriverFolder = Directory.GetCurrentDirectory() + @"\WebDriver\" + $"{type}";
            
            switch (type)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    //options.AddArguments("start-maximized");
                    Driver = new ChromeDriver(DriverFolder);
                    break;
                case BrowserType.FireFox:
                    Driver = new FirefoxDriver(DriverFolder);
                    break;
                default: throw new Exception("Please enter correct driver!");
            }
            return Driver;
        }



    }
}
