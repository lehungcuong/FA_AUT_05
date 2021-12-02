using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace XUnitTest_POM_Webdriver
{
    public class BrowserFactory
    {
        public static IWebDriver driver;
        public WebDriverWait wait;
        public static Actions actions;

        public BrowserFactory(BrowserType type, string url)
        {
            driver = GetIWebDriver(type, url);
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            actions = new Actions(driver);
        }

        /// <summary>
        /// Close Browser
        /// </summary>
        public static void CloseBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }

        /// <summary>
        /// Find element
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IWebElement FindElement(string value)
        {
            return driver.FindElement(By.XPath(value));
        }

        /// <summary>
        /// Find list elements
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IList<IWebElement> FindElements(string value)
        {
            return driver.FindElements(By.XPath(value));
        }

        /// <summary>
        /// Click on an element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                Console.WriteLine("Error: Element click intercepted exception on page " + driver.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown error " + ex.Message + " on page " + driver.Title);
            }
        }

        /// <summary>
        /// Clear text 
        /// </summary>
        /// <param name="element"></param>
        public static void ClearText(IWebElement element)
        {
            try
            {
                element.Clear();
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
        /// <returns></returns>
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
        /// <returns></returns>
        public static string GetTitle()
        {
            try { return driver.Title; }
            catch (Exception ex)
            {
                return "Unknown error " + ex.Message + " on page " + driver.Title;
            }
        }

        /// <summary>
        /// Scroll to element before click
        /// </summary>
        /// <param name="element"></param>
        public static void ClickScroll(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            Thread.Sleep(500);
            element.Click();
        }

        /// <summary>
        /// List browsers for test
        /// </summary>
        public enum BrowserType
        {
            Chrome, Firefox
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
                    driver = new ChromeDriver(driverFolder, option) { Url = url };
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver(driverFolder) { Url = url };
                    break;
                default: throw new Exception("Browser don't exist. Input again");
            }
            return driver;
        }
    }
}
