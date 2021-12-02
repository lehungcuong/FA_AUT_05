using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using Xunit;
using XunitPOM.Utilities;

namespace WebDriver
{
    public class BrowserFactory
    {
        private static IJavaScriptExecutor Jse;
        private static WebDriverWait wait;
        private static Actions actions;
        private readonly TimeSpan timeout = TimeSpan.FromSeconds(30);
        public IWebDriver driver;
        private static readonly string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public static bool status;

        public BrowserFactory(string type, string url) 
        {
            driver = GetWebDriver(type, url);
            wait = new WebDriverWait(driver, timeout);
            actions = new Actions(driver);
            Jse = (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Get driver from config and create new driver
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static IWebDriver GetWebDriver(string type, string url)
        {
            IWebDriver driver;
            string driverFolder = SolutionPath  + @"\WebDriver\WebDriver\" + $"{type}" + "Driver";
            BrowserType driverType = type.Equals("Chrome") ? BrowserType.ChromeDriver : BrowserType.FirefoxDriver;
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            switch (driverType)
            {
                case BrowserType.ChromeDriver:
                    driver = new ChromeDriver(driverFolder, options);
                    break;
                case BrowserType.FirefoxDriver:
                    driver = new FirefoxDriver(driverFolder);
                    break;
                default:
                    driver = new ChromeDriver(driverFolder, options);
                    break;
            }
            driver.Url = url;
            return driver;
        }

        /// <summary>
        /// Wait to element to visible
        /// </summary>
        /// <param name="locator"></param>
        /// <returns> IWebelement </returns>
        public static IWebElement FindElement(By locator) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

        /// <summary>
        /// Get current page title
        /// </summary>
        /// <returns> string </returns>
        /// <exception cref="WebDriverException"></exception>
        public string getPageTitle()
        {
            try
            {
                return string.Format("Current page title is: {0}", driver.Title);
            }
            catch (WebDriverException)
            {
                throw new WebDriverException(string.Format("Current page title is: {0}", driver.Title));
            }
        }

        /// <summary>
        /// Scroll to element before click
        /// </summary>
        /// <param name="element"></param>
        public static void Click(IWebElement element)
        {
            Jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            //IWebElement test = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            Thread.Sleep(500);
            element.Click();
        }

        /// <summary>
        /// Select case helper
        /// </summary>
        /// <param name="element"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <exception cref="Exception"></exception>
        public static void select(IWebElement element, SelectType type, string options)
        {
            SelectElement select = new SelectElement(element);
            switch (type)
            {
                case SelectType.SELECT_BY_INDEX:
                    try
                    {
                        select.SelectByIndex(Int32.Parse(options));
                    }
                    catch
                    {
                        throw new Exception("Please input numberic on selectOption for SelectType.SelectByIndex");
                    }
                    break;
                case SelectType.SELECT_BY_TEXT:
                    select.SelectByText(options);
                    break;
                case SelectType.SELECT_BY_VALUE:
                    select.SelectByValue(options);
                    break;
                default:
                    throw new Exception("Error when using selected");
            }
        }

        /// <summary>
        /// Clear text before send
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <exception cref="WebDriverException"></exception>
        public static void setText(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverException)
            {
                throw new WebDriverException("Element is not enable to set text");
            }
        }

        /// <summary>
        /// Assert bool type and set test status
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public static void AssertBool(bool value, bool type)
        {
            switch (type)
            {
                case true:
                    try
                    {
                        Assert.True(value);
                        status = true;
                    }
                    catch
                    {
                        status = false;
                    }
                    break;
                case false:
                    try
                    {
                        Assert.False(value);
                        status = true;
                    }
                    catch
                    {
                        status = false;
                    }
                    break;
            }
        }
    }
}