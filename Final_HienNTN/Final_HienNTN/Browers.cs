using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HienNTN
{
    public class Browers
    {
        public IWebDriver driver;
        public Browers(BrowserType type, string URL)
        {
            driver = GetWebDriver(type, URL);
        }
        public enum BrowserType
        {
            Chrome, FireFox
        }
        /// <summary>
        /// Get Web Driver
        /// </summary>
        /// <param name="type"></param>
        /// <param name="URL"></param>
        /// <returns>driver</returns>
        public static IWebDriver GetWebDriver(BrowserType type, string URL)
        {
            IWebDriver driver;
            string driverFolder = Directory.GetCurrentDirectory() + @"\WebDriver\" + $"{type}";
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            switch (type)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver(driverFolder, options);
                    break;
                case BrowserType.FireFox:
                    driver = new FirefoxDriver(driverFolder);
                    break;
                default:
                    throw new Exception("Please enter correct driver");
            }
            driver.Url = URL;
            return driver;
        }
    }
}
