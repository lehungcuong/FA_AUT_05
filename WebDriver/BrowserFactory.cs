using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using XunitPOM.Utilities;

namespace WebDriver
{
    public class BrowserFactory
    {
        private static IJavaScriptExecutor Jse;
        private static WebDriverWait wait;
        private static Actions actions;
        private static readonly TimeSpan timeout = TimeSpan.FromSeconds(30); 
        private static readonly string SolutionPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public IWebDriver driver;

        public BrowserFactory(string type, string url) 
        {
            driver = GetWebDriver(type, url);
            actions = new Actions(driver);
            Jse = (IJavaScriptExecutor)driver;
            wait = new WebDriverWait(driver, timeout);
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
            options.AddArguments("--start-maximized");
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
        /// Move to element before click
        /// </summary>
        /// <param name="element"></param>
        public static void Click(IWebElement element)
        {
            actions.MoveToElement(element).Build().Perform();
            element.Click();
        }

        /// <summary>
        /// Click by javascript
        /// </summary>
        /// <param name="element"></param>
        public static void JsClick(IWebElement element)
        {
            Jse.ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// Scroll and move to element before click
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollAndClick(IWebElement element)
        {
            Jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);  
            Thread.Sleep(1000);
            WaitFor(() => element.Enabled && element.Displayed == true, 30).Should().BeTrue();
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
        /// Assert bool type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public static void AssertValueBool(bool value, AssertType type, string message)
        {
            switch (type)
            {
                case AssertType.True:
                    value.Should().BeTrue(message);
                    break;
                case AssertType.False:
                    value.Should().BeFalse(message);
                    break;
            }
        }

        /// <summary>
        /// Assert value null or not
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void AssertValueNullOrNot(string value, AssertType type, string message)
        {
            switch (type)
            {
                case AssertType.Null:
                    value.Should().BeNull(message);
                    break;
                case AssertType.NotNull:
                    value.Should().NotBeNull(message);
                    break;
            }
        }

        /// <summary>
        /// Assert value empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void AssertValueEmpty(string value, string message)
        {
            value.Should().BeEmpty();
        }

        /// <summary>
        /// Assert two string value
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public static void AssertValueEqual(string value1, string value2, string message)
        {
            value1.Should().Be(value2, message);
        }

        /// <summary>
        /// Wait helper
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool WaitFor(
        Func<bool> condition,
        int timeout = 5)
        {
            var watch = new Stopwatch();
            bool result = false;
            watch.Start();
            while (true)
            {
                try
                {
                    if (condition())
                    {
                        result = true;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // Stop wait helper
                    if (ex.Message.Contains("Testcase Fail")) throw;
                }
                if (watch.Elapsed.TotalSeconds >= timeout)
                {
                    watch.Stop();
                    break;
                }
            }
            return result;
        }
    }
}