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

namespace XUnitTest_POM_Webdriver
{
    public class BrowserFactory
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public static IJavaScriptExecutor jse;

        public BrowserFactory(BrowserType type, string url)
        {
            driver = GetIWebDriver(type, url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            jse = (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Get IWebDriver by browser and url
        /// </summary>
        /// <param name="type"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IWebDriver GetIWebDriver(BrowserType type, string url)
        {
            string driverFolder = Directory.GetCurrentDirectory() + @"\WebDriver\" + $"{type}";
            switch (type)
            {
                case BrowserType.Chrome:
                    ChromeOptions option = new();
                    option.AddArguments("start-maximized");
                    driver = new ChromeDriver(driverFolder, option);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver(driverFolder);
                    break;
                default: throw new Exception("Browser don't exist. Input again");
            }
            driver.Url = url;
            return driver;
        }

        /// <summary>
        /// Close Browser
        /// </summary>
        public static void CloseBrowser()
        {
            driver.Dispose();
            driver.Quit();
        }

        /// <summary>
        /// Find locator
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns> Locator </returns>
        public static By Locator(string path, FindType type = FindType.Defined)
        {
            if(path.StartsWith(".") || path.StartsWith("/") || path.StartsWith("("))
            {
                return By.XPath(path);
            }
            var indexPath = path.IndexOf(":");
            var value = path.Substring(indexPath + 1);
            if(type == FindType.Defined)
            {
                Enum.TryParse(path.Substring(0, indexPath), out type);
            }
            switch (type)
            {
                case FindType.Id: return By.Id(value);
                case FindType.Name: return By.Name(value);
                case FindType.ClassName: return By.ClassName(value);
                case FindType.LinkText: return By.CssSelector(value);
                case FindType.PartialLinkText: return By.PartialLinkText(value);
                case FindType.CssSelector: return By.CssSelector(value);
                case FindType.XPath: return By.XPath(value);
                default: throw new Exception("Locator type " + value + " not defined");
            }
        }

        /// <summary>
        /// Find element
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IWebElement FindElement(string path) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(Locator(path)));
        
        /// <summary>
        /// Find list elements
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IList<IWebElement> FindElements(string path) => driver?.FindElements(Locator(path));

        /// <summary>
        /// Click on an element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(IWebElement element)
        {
            try
            {
                jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
                Thread.Sleep(500);
                element.Click();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unknown error " + ex.Message + " on page " + driver.Title);
            }
        }

        /// <summary>
        /// Send keys to element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        public static void SendKeys(IWebElement element, string key)
        {
            try
            {
                element.Clear();
                element.SendKeys(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error " + ex.Message + " on page " + driver.Title);
            }
        }

        /// <summary>
        /// Select an element by text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SelectElementByText(IWebElement element, string text)
        {
            try
            {
                SelectElement select = new(element);
                select.SelectByText(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error " + ex.Message + " on page " + driver.Title);
            }
        }

        /// <summary>
        /// Select an element by value (can use in any language)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SelectElementByValue(IWebElement element, string text)
        {
            try
            {
                SelectElement select = new(element);
                select.SelectByValue(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error " + ex.Message + " on page " + driver.Title);
            }

        }

        /// <summary>
        /// Get text of element
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Text</returns>
        public static string GetText(IWebElement element)
        {
            try { return element.Text; }
            catch (Exception ex)
            {
                return "Unknown error " + ex.Message + " on page " + driver.Title;
            }
        }

        /// <summary>
        /// Get title of page
        /// </summary>
        /// <returns>Title</returns>
        public static string GetTitle()
        {
            try { return driver.Title; }
            catch (Exception ex)
            {
                return "Unknown error " + ex.Message + " on page " + driver.Title;
            }
        }

        public static void FluentAssert(bool value, string message) => value.Should().BeTrue(because: message); 

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

        public static void CheckElementisdisplayed(string value) => WaitFor(() =>
        {
            return FindElement(value).Displayed;
        }, 300).Should().BeTrue(because: "Fail!!!");
    }
}
