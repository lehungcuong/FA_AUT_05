using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using static WebDriverFactory.Browser;

namespace WebDriverFactory
{
    public class BrowserFactory
    {
        public static IWebDriver Driver;
        public static IJavaScriptExecutor Jse;
        public static WebDriverWait wait;

        public BrowserFactory(BrowserType type, string url)
        {
            Driver = GetWebDriver(type, url);
            Jse = (IJavaScriptExecutor)Driver;
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        public static IWebDriver GetWebDriver(BrowserType type, string uri)
        {
            // IWebDriver driver;
            string driverFolder = Directory.GetCurrentDirectory() + @"\WebDriver\" + $"{type}";
            switch (type)
            {
                case BrowserType.Chrome:
                    ChromeOptions optionCH = new ChromeOptions();
                    optionCH.AddArguments("start-maximized");
                    optionCH.AddArguments("no-sandbox");
                    optionCH.AddArguments("--remote-debugging-port=0");
                    Driver = new ChromeDriver(driverFolder, optionCH, TimeSpan.FromSeconds(60));
                    break;
                case BrowserType.FireFox:
                    FirefoxOptions optionFF = new FirefoxOptions();
                    optionFF.AddArguments("start-maximized");
                    Driver = new FirefoxDriver(driverFolder,optionFF);
                    break;
                default: throw new Exception("Please enter Driver ");
            }
            Driver.Url = uri;
            return Driver;
        }

        public static IWebElement FindElement(By locator) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));


        /// <summary>
        /// get website element by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement SetWebElement(string path) => FindElement(By.XPath(path));
        /// <summary>
        /// get multi element by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IList<IWebElement> SetWebElements(string path) => Driver.FindElements(By.XPath(path));
        /// <summary>
        /// Click action element
        /// 
        /// </summary>
        /// <param name="element"></param>
        //public static void Click(IWebElement element)
        //{
        // //   Jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        // //   WaitFor(()=>element.Displayed,5);

        //    element.Click();
        //}
        public static void Click(IWebElement element)
        {
            Jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            Thread.Sleep(1000);
            element.Click();
        }

        public static void ClickJS(IWebElement element)
        {
            Jse.ExecuteScript("arguments[0].click();", element);
        }

        public static void Select(IWebElement element, String type, String choose)
        {
            SelectElement selectElement = new SelectElement(element);
            switch (type)
            {
                case "Index":
                    try
                    {
                        selectElement.SelectByIndex(int.Parse(choose));
                    }
                    catch
                    {
                        throw new Exception("Choose must be number");
                    }
                    break;
                case "Value":
                    selectElement.SelectByValue(choose);
                    break;
                case "Text":
                    selectElement.SelectByText(choose);
                    break;
            }

        }
        /// <summary>
        /// Send Key to element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="Key"></param>
        public static void sendKey(IWebElement element, string Key)
        {
            try
            {
                element.Clear();
                element.SendKeys(Key);
            }
            catch (WebDriverException ex)
            {
                throw new WebDriverException(ex.Message);
            }
        }
        /// <summary>
        /// wait to condition true
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

        public void AssertValue(bool value, AssertType type, string message)
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

        public void AssertValue(string value1, string value2, string message)
        {
            value1.Should().Be(value2, message);
        }
    }
}
