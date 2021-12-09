using AventStack.ExtentReports;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;
using XunitPOM.Constants;
using XunitPOM.Utilities;

namespace WebDriver
{
    public class BrowserFactory
    {
        private static IJavaScriptExecutor jse;
        private static WebDriverWait wait;
        private static Actions actions;
        private static readonly TimeSpan timeout = TimeSpan.FromSeconds(30);
        public IWebDriver driver;

        public BrowserFactory(string type, string url) 
        {
            driver = GetWebDriver(type, url);
            actions = new Actions(driver);
            jse = (IJavaScriptExecutor)driver;
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
            // Fix directory to bin
            string driverFolder = DataConstant.BinPath + @"\WebDriver\" + $"{type}" + "Driver";

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
            jse.ExecuteScript("arguments[0].click();", element);
        }

        /// <summary>
        /// Scroll and move to element before click
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollAndClick(IWebElement element)
        {
            jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);  
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
        public static void AssertValueBool(bool value, AssertType type, string failMessage, string successMessage)
        {
            switch (type)
            {
                case AssertType.True:
                    value.Should().BeTrue(failMessage);
                    ReportHelper.extentTest.Log(Status.Pass, successMessage);
                    break;
                case AssertType.False:
                    value.Should().BeFalse(failMessage);
                    ReportHelper.extentTest.Log(Status.Pass, successMessage);
                    break;
            }
        }

        /// <summary>
        /// Assert value null or not
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void AssertValueNullOrNot(string value, AssertType type, string failMessage, string successMessage)
        {
            switch (type)
            {
                case AssertType.Null:
                    value.Should().BeNull(failMessage);
                    ReportHelper.extentTest.Log(Status.Pass, successMessage);
                    break;
                case AssertType.NotNull:
                    value.Should().NotBeNull(failMessage);
                    ReportHelper.extentTest.Log(Status.Pass, successMessage);
                    break;
            }
        }

        /// <summary>
        /// Assert value empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public static void AssertValueEmpty(string value, string failMessage, string successMessage)
        {
            value.Should().BeEmpty(failMessage);
            ReportHelper.extentTest.Log(Status.Pass, successMessage);
        }

        /// <summary>
        /// Assert two string value
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public static void AssertValueEqual(string value1, string value2, string failMessage, string successMessage)
        {
            value1.Should().Be(value2, failMessage);
            ReportHelper.extentTest.Log(Status.Pass, successMessage);
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