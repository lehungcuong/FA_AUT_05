using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using FluentAssertions;
namespace POM_Driver
{
    public class BrowserFactory
    {
        public enum BrowserType { Chrome, Firefox }
        public static IWebDriver driver;
        private static WebDriverWait wait;
        public static IJavaScriptExecutor jse;

        public BrowserFactory(BrowserType browserType, string url)
        {
            driver = GetDriver( browserType, url);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            jse = (IJavaScriptExecutor)driver;
        }

        /// <summary>
        /// Get driver 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="browserType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IWebDriver GetDriver(BrowserType browserType,string url)
        {
            string filePath = Directory.GetCurrentDirectory() + @"\Browser\" + $"{browserType}";
            // string driverFolder = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, Path.Combine(@"\Browser\", $"{browserType}"));
            ChromeOptions options = new ChromeOptions();
            switch (browserType)
            {
                case BrowserType.Chrome:
                    options.AddArguments("start-maximized");
                    driver = new ChromeDriver(filePath, options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver(filePath);
                    break;
                default: throw new Exception("Not correct!!!!!");
            }
            return driver;
        }

        /// <summary>
        /// Clear value in element
        /// </summary>
        /// <param name="xpath"></param>
        public static void ClearValue(string xpath) => GetElement(xpath).Clear();

        /// <summary>
        /// Get Element by any path path 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="startFrom"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IWebElement GetElement(string path, IWebElement startFrom = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            var from = startFrom ?? (ISearchContext)driver;
            var element = @from.FindElement(ParseBy(path));
            return element;
        }

        /// <summary>
        /// Get List emlement
        /// </summary>
        /// <param name="path"></param>
        /// <param name="startFrom"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> GetListElement (string path, IWebElement startFrom = null)
        {
            var from = startFrom ?? (ISearchContext)driver;

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
        /// <summary>
        /// Get Title of pages
        /// </summary>
        /// <returns>Driver?.Title</returns>
        public static string GetTitle() => driver?.Title;

        /// <summary>
        /// Click on element by locator
        /// </summary>
        /// <param name="xpath"></param>
        public static void ClickElenment(string locator)
        {
            try
            {
                MoveToElement(locator);
                GetElement(locator).Click();
                Thread.Sleep(1000);
            }
            catch (WebDriverException)
            {
                throw new WebDriverException("Fail!! Don't click on element!!!");
            }
        }
        public static void ClickElenmentByJS(string locator)
        {
            try
            {
                jse.ExecuteScript("arguments[0].click();", GetElement(locator));
            }
            catch (WebDriverException)
            {
                throw new WebDriverException("Fail!! Don't click on element!!!");
            }
        }

        /// <summary>
        /// assign value to element
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="value"></param>
        public static void SendValue(string locator, string value)
        {
            try
            {
                ClearValue(locator);
                GetElement(locator).SendKeys(value);
            }
            catch (WebDriverException)
            {
                throw new WebDriverException("Fail!! Don't set text in element!!!");
            }
        }

        /// <summary>
        /// 
        /// Move To Element to position in list element
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static IWebElement MoveToElementInListElement(string locator, int position)
        {
            IWebElement element = GetListElement(locator).ElementAt(position);
            jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            CheckElementIsdisplayed(locator);
            // becase size of element = 0 should use thread 
            Thread.Sleep(500);
            element.Click();
            return element;
        }

        // <summary>
        /// Move To 1 Element
        /// </summary>
        /// <param name="locator"></param>
        public static void MoveToElement(string locator)
        {
            IWebElement element = GetElement(locator);
            jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            CheckElementIsdisplayed(locator);
            // becase size = 0 should use thread 
            Thread.Sleep(1000);
        }
        /// <summary>
        /// Wait For
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool WaitFor(Func<bool> condition, int timeout = 5)
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
        /// <summary>
        /// Check Element is displayed
        /// </summary>
        /// <param name="path"></param>
        public static void CheckElementIsdisplayed(string path) => WaitFor(() =>
        {
            return GetElement(path).Displayed;
        }, 300).Should().BeTrue(because: "Fail!!!");

        /// <summary>
        /// Select Value In DropDown
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="value"></param>
        public static void SelectValueInDropDown(string xpath, string value)
        {
            try
            {
                var selectValue = new SelectElement(driver.FindElement(By.XPath(xpath)));
                selectValue.SelectByValue(value);
            }
            catch (WebDriverException)
            {
                throw new WebDriverException("Fail!! Don't select value in element!!!");
            }
        }
        /// <summary>
        /// Asstert Title Page
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool AsstertTitlePage(string text)
        {
            bool flag;
            try
            {
                flag = GetTitle() == text ? true : false;
                flag.Should().BeTrue("Title page not equal!");
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static void AsstertText(string locator, string text)
        {
            bool flag = GetTextInElement(locator) == text ? true : false;
            flag.Should().BeTrue("Text page not equal!");
        }
        public static string GetTextInElement(string locator) => GetElement(locator).Text;
    }
}
