using BrowserFactory.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Xunit;

namespace BrowserFactory
{
    public class BrowsersFactory
    {

        private static IWebDriver? _driver;

        /// <summary>
        /// Choose browser type
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public IWebDriver Create(LocalDriverConfig configuration)
        {
            //A simple switch statement to determine which driver/service to create.
            switch (configuration.Browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver("Browsers");

                    break;

                case "Firefox":
                    _driver = new FirefoxDriver("Browsers");
                    break;

                //If a string isn't matched, it will default to ChromeDriver
                default:
                    _driver = new ChromeDriver("Browsers");
                    break;
            }

            //Return the driver instance to the calling class.
            return _driver;
        }

        /// <summary>
        /// Get the IWebElement at the specified Path
        /// Throws if the element is not found
        /// </summary>
        /// <param name="path">Selector for the element</param>
        /// <param name="startFrom">Parent Element</param>
        /// <returns></returns>
        public static IWebElement Get(
            string path,
            IWebElement startFrom = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var from = startFrom ?? (ISearchContext)_driver;
            var element = @from.FindElement(ParseBy(path));

            return element;
        }

        public ReadOnlyCollection<IWebElement> GetMultiple(
            string path,
            IWebElement startFrom = null)
        {
            var from = startFrom ?? (ISearchContext)_driver;

            return from.FindElements(ParseBy(path));
        }

        private static By ParseBy(string path, How how = How.Undefined)
        {
            if (path.StartsWith("/") || path.StartsWith(".") || path.StartsWith("("))
            {
                return By.XPath(path);
            }

            var pathSplit = path.IndexOf(':');
            var value = path.Substring(pathSplit + 1);
            if (how == How.Undefined)
            {
                Enum.TryParse(path.Substring(0, pathSplit), true, out how);
            }

            if (how == How.Undefined)
            {
                how = How.XPath;
            }

            switch (how)
            {
                case How.Id: return By.Id(value);
                case How.Name: return By.Name(value);
                case How.ClassName: return By.ClassName(value);
                case How.Tag: return By.TagName(value);
                case How.Link: return By.LinkText(value);
                case How.PartialLink: return By.PartialLinkText(value);
                case How.Css: return By.CssSelector(value);
                case How.XPath: return By.XPath(value);
                default:
                    throw new Exception($"Locator type \"{how}\" not defined");
            }
        }

        /// <summary>
        /// Click Element
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
                Console.WriteLine("Element unable to click because " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Input Text into Textbox
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void InputText(IWebElement element, string text)
        {

            try
            {
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element unable to input text because: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Select Element from List
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectElement(IWebElement element, string value)
        {

            try
            {
                SelectElement ddlCountry = new SelectElement(element);
                ddlCountry.SelectByValue(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element unable to select because: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Click Element by JavaScript using ID
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void ClickElementJS(IWebDriver driver, IWebElement element)
        {

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element unable to click because: " + e.Message);
                throw;
            }
        }

        public static void ClearTextbox(IWebElement element)
        {
            element.Clear();
        }

        /// <summary>
        /// Click Element by JavaScript using XPATH
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void ClickElementJSXPATH(IWebDriver driver, IWebElement element)
        {

            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element unable to click because: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Assert Element Text same as expected
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void AssertElementText(IWebElement element, string text)
        {
            Assert.Equal(text, element.Text);
        }

        /// <summary>
        /// Assert Page Title same as expected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="title"></param>
        public static void AssertPageTitle(IWebDriver driver, string title)
        {

            try
            {
                Assert.Equal(title, driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Page title is not same as expected because: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Get Element From List and stored to element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="location"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static WebElement GetElementFromList(IWebDriver driver, string location, int index)
        {

            try
            {
                IList<WebElement> tour = new List<WebElement>();
                foreach (WebElement item in driver.FindElements(By.XPath(location)))
                {
                    tour.Add(item);
                }
                return tour[index - 1];
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't get element from list because: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Assert Element Contains Text 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public static void AssertElementContainsText(IWebElement element, string text)
        {

            try
            {
                Assert.Contains(text, element.Text);
            }
            catch (Exception e)
            {
                Console.WriteLine("Element does not contains expected text beacuse: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Convert Element Text
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string ConvertElementText(WebElement element)
        {
            try
            {
                string elementName = element.Text;
                var tourNameToAssert = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(elementName.ToLowerInvariant());
                return tourNameToAssert;
            }
            catch (Exception e)
            {
                Console.WriteLine("Element text can't be convert because: " + e.Message);
                throw;
            }
        }

        public enum How
        {
            Undefined,
            Id,
            Name,
            ClassName,
            Tag,
            Link,
            PartialLink,
            Css,
            XPath
        }
    }
}
