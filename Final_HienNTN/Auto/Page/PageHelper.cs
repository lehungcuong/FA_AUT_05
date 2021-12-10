using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Auto.Page
{
    public class PageHelper
    {
        private IWebDriver Driver;
        string MessageError = "Invalid value";
        private static WebDriverWait wait;

        public PageHelper(IWebDriver driver)
        {
            Driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));

        }
        public IWebElement FindElement(By locator) => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

        /// <summary>
        /// Funcition click element
        /// </summary>
        /// <param name="element"></param>
        public void ClickEL(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                Console.WriteLine(MessageError);
            }
        }
        /// <summary>
        /// Funcition input text for element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        public void SenkeyEL(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception)
            {
                Console.WriteLine(MessageError);
            }
        }
        /// <summary>
        /// Funcition Click JavaSript for Element
        /// </summary>
        /// <param name="element"></param>
        public void ClickJSEL(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].click()", element);
          
        }
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="text"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool ValidateWebTitle(string text, IWebElement element)
        {
            return (element.Text == text) ? true : false;

        }
        /// <summary>
        /// Funciton Select Element by text
        /// </summary>
        /// <param name="xpath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public SelectElement SelectELByValue(string xpath, string value)
        {
            SelectElement selectElement = new SelectElement(Driver.FindElement(By.XPath(xpath)));
            selectElement.SelectByValue(value);
            return selectElement;
        }
        /// <summary>
        /// Scroll Windown 
        /// </summary>
        public void ScrollWindown(IWebDriver webDriver, int scroll)
        {
            try
            {
                IJavaScriptExecutor jse1 = (IJavaScriptExecutor)Driver;
                jse1.ExecuteScript($"scroll(0, {scroll});");
                Thread.Sleep(2000);
            }
            catch (Exception)
            {
                Console.WriteLine(MessageError);
                throw;
            }
        }
    }
}

