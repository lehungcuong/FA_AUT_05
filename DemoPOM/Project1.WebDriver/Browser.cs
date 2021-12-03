using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using static Project1.WebDriver.Browser;

namespace Project1.WebDriver
{
    public class Browser
    {
        public static IWebDriver Driver;
        public static WebDriverWait wait;
        public Browser(BrowserType type)
        {
            Driver = BrowserFactory.GetWebDriver(type);
            wait = new WebDriverWait(Browser.Driver, System.TimeSpan.FromSeconds(30));
        }

        public enum BrowserType
        {
            Chrome, Firefox
        }

        public static void GoToPage(string url)
        {
            Driver.Url = url;
        }

        public static IWebElement GetElement(By locator) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        
        public static void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickToElement(IWebElement element)
        {
            element.Click();
        }

        public static void SelectElement(IWebElement element, string text)
        {
            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(text);
        }

        public static void  ScrollByJScript(string js)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.Driver;
            jse.ExecuteScript(js);
        }


        public static bool ValidateWebTitle(string pageTitle)
        {
            bool assert = (Browser.Driver.Title == pageTitle) ? true : false;
            assert.Should().BeTrue("Go to page unsuccessful!");
            return assert;
        }

    }

    public class BrowserFactory
    {
        // Get Browser: Chrome or FireFox 
        public static IWebDriver GetWebDriver(BrowserType type)
        {
            IWebDriver driver;
            string driverFolder = string.Empty;
            switch (type)
            {
                case BrowserType.Chrome:
                    driverFolder = Directory.GetCurrentDirectory() + @"\Driver\" + $"{type}";
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    driver = new ChromeDriver(driverFolder, options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver(driverFolder);
                    break;
                default: throw new System.Exception("Incorrect browser type");
            }
            return driver;
        }
    }
}
