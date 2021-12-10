using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace XUnitTestPage_automationpractice.com.Utilities
{
    public class WebKeyword
    {
        public IWebDriver driver;
        private static IJavaScriptExecutor jse;

        private readonly TimeSpan timeout = TimeSpan.FromSeconds(120);
        private static WebDriverWait wait;
        private static Actions actions;

        public WebKeyword(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1200);
            wait = new WebDriverWait(this.driver, timeout);
            jse = (IJavaScriptExecutor)this.driver;
            actions = new Actions(this.driver);
        }
        public string GetURL() => driver.Url;

        /// <summary>
        /// click on element
        /// </summary>
        /// <param name="element"></param>
        public void Click(IWebElement element)
        {
            jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            Thread.Sleep(400);
            WaitFor(() => element.Enabled && element.Displayed == true, 10).Should().BeTrue();
            actions.MoveToElement(element).Build().Perform();

            element.Click();
        }

        public void ClickElementJS(IWebElement element)
        {
            jse.ExecuteScript("arguments[0].click();", element);
        }

        public void MoveToElementAndClick(IWebElement elementToMove, IWebElement elementToClick)
        {
            //hover
            actions.MoveToElement(elementToMove).MoveToElement(elementToClick).Click().Build().Perform();
            //snip to elemnt and click
            
        }

        //public IWebElement FindElement(By locator) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        public IWebElement FindElement(By locator) => driver.FindElement(locator);

        /// <summary>
        /// send text to IWebElement
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <exception cref="WebDriverException"></exception>
        public void SetText(IWebElement element, string text)
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
        /// select element of drop down list
        /// </summary>
        /// <param name="select"></param>
        /// <param name="value"></param>
        public void ConvertAndSelectElementByValue(IWebElement selectElement, string value)
        {
            try
            {
                SelectElement select = new SelectElement(selectElement);
                select.SelectByValue(value);
            }
            catch (NullReferenceException RefEx)
            {
                Console.WriteLine("element can not found" + RefEx);
            }
            catch (WebDriverException WDEx)
            {
                Console.WriteLine("element is not enable to select item: " + WDEx);
            }
        }
        /// <summary>
        /// set value by text
        /// </summary>
        /// <param name="selectElement"></param>
        /// <param name="name"></param>
        public void ConvertAndSelectElementByText(IWebElement selectElement, string name)
        {
            try
            {
                SelectElement select = new SelectElement(selectElement);
                select.SelectByText(name);
            }
            catch (NullReferenceException RefEx)
            {
                Console.WriteLine("element can not found" + RefEx);
            }
            catch (WebDriverException WDEx)
            {
                Console.WriteLine("element is not enable to select item: " + WDEx);
            }
        }
        /// <summary>
        /// maximize window browser
        /// </summary>
        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// return list element
        /// </summary>
        /// <param name="element">IWebElement hold the list</param>
        /// <param name="locator">address of list elements</param>
        /// <returns></returns>
        public IList<IWebElement> ParseToList(IWebElement element, By locator)
        {
            IList<IWebElement> result;
            result = element.FindElements(locator);
            return result;
        }

        /// <summary>
        /// Get current page title
        /// </summary>
        /// <returns> string </returns>
        /// <exception cref="WebDriverException"></exception>
        public string GetPageTitle()
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

        /// <summary>
        /// Assert bool type and set test status
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public static void AssertValue(bool value, AssertType type, string message)
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
        /// Assert two string value
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public static void AssertValue(string value1, string value2, string message)
        {
            value1.Should().Be(value2, message);
        }   
    }

    public enum AssertType
    {
        True,
        False
    }
}
