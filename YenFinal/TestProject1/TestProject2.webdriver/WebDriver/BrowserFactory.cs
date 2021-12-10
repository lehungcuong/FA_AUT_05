using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

using System.Threading;

namespace TestProject2.WebDriver.WebDriver
{
    public class BrowserFactory
    {
        public IWebDriver driver;

      

        public BrowserFactory(BrowserType type, string url)
        {
            driver = GetWebDriver(type, url);
        }
        /// <summary>
        /// Get Web Driver
        /// </summary>
        /// <param name="type"></param>
        /// <param name="URL"></param>
        /// <returns></returns>
        public static IWebDriver GetWebDriver(BrowserType type, string URL)
        {
            IWebDriver driver;


            switch (type)
            {
                case BrowserType.Chorme:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("start-maximized");
                    driver = new ChromeDriver(@"WebDriver\Chrome", chromeOptions);
                    break;
                case BrowserType.FireFox:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments("start-maximized");
                    driver = new FirefoxDriver(@"WebDriver\Firefox", firefoxOptions);
                    break;
                default: throw new Exception("Please enter corext driver");
            }
            driver.Url = URL;
            return driver;



        }
        public enum BrowserType
        {
            Chorme, FireFox
        }
        /// <summary>
        /// Funtion click element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(IWebElement element)
        {
            try
            {

                element.Click();

            }

            catch (Exception e)
            {
                Console.WriteLine("Unable to click" + e.Message);
                throw;
            }

        }

        /// <summary>
        /// funtion To Click Element by JavaScrip
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="element"></param>
        public static void ClickElementJavaScrip(IWebDriver webDriver, IWebElement element)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            IWebElement elementJS = element;
            js.ExecuteScript("arguments[0].click();", elementJS);
        }
        /// <summary>
        /// Funtion To Scroll To Element
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="scroll"></param>
        public static void ScrollToElement(IWebDriver webDriver, int scroll)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                js.ExecuteScript($"scroll(0, {scroll});");
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to Scroll" + e.Message);
                throw;
            }

        }
        /// <summary>
        /// Funtion To Enter Data
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SendKey(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to Enter text" + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Funtion Select By Texts
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void SelectByTexts(IWebElement element, string text)
        {
            try
            {
                SelectElement selectContry = new SelectElement(element);
                selectContry.SelectByText(text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to select text" + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Assert Page Tittle use FluentAssertions
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="tittle"></param>
        /// <returns></returns>
        public static bool AssertPageByTittle(IWebDriver webDriver, string tittle)
        {
            bool assertPage = (webDriver.Title == tittle) ? true : false;
            assertPage.Should().BeTrue("result Page title's not same expected");
            return assertPage;



        }
    }
}
