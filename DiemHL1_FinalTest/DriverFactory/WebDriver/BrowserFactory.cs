using System;
using System.IO;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using static PHP_Travel_DriverFactory.WebDriver.Browser;

namespace DriverFactory.WebDriver
{
    public class BrowserFactory
    {
        public IWebDriver Driver;
        private static WebDriverWait wait;

        /// <summary>
        /// List Browser Types
        /// </summary>
        public enum BrowserType
        {
            Chrome, Firefox
        }

        /// <summary>
        /// Initialize Driver
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        public BrowserFactory(BrowserType type, string url)
        {
            Driver = GetIWebDriver(type, url);
        }

        /// <summary>
        /// Consider the case to get browser Chrome or FireFox 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <returns> Driver </returns>
        public static IWebDriver GetIWebDriver(BrowserType type, string url)
        {
            IWebDriver Driver;
            string driverFolder = Directory.GetCurrentDirectory() + @"\WebDriver\" + $"{type}";
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            switch (type)
            {
                case BrowserType.Chrome:
                    Driver = new ChromeDriver(driverFolder, options);
                    break;

                case BrowserType.Firefox:
                    Driver = new FirefoxDriver(driverFolder);
                    break;

                default: throw new Exception(" Input Browser");
            }
            Driver.Url = url;
            return Driver;
        }

        public BrowserFactory(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        /// <summary>
        /// Use Assert to compare 2 values and return the result message
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public void AssertFluent(bool value, AssertResult type, string message)
        {
            switch (type)
            {
                case AssertResult.True:
                    value.Should().BeTrue(message);
                    break;
                case AssertResult.False:
                    value.Should().BeFalse(message);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Use Assert to compare 2 values and return the result message
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="message"></param>
        public void AssertFluent(string value1, string value2, string message)
        {
            value1.Should().Be(value2, message);
        }
    }
}
