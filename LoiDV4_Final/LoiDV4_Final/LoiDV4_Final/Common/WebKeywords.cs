using DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LoiDV4_Final.Common
{
    public static class WebKeywords
    {
        /// <summary>
        /// This method use for cLick element
        /// </summary>
        /// <param name="element"></param>
        public static void Click(IWebElement element)
        {
            try
            {
                //Actions action = new Actions(BrowserFactory.Driver);
                //action.MoveToElement(element).Build().Perform();
                element.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method user for enter text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <exception cref="StepErrorException"></exception>
        public static void SetText(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method is use for scroll to element
        /// </summary>
        /// <param name="element"></param>
        public static void ScrollToViewElement(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)BrowserFactory.Driver;
                js.ExecuteScript("arguments[0].scrollIntoView(false);", element);
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
        /// <summary>
        /// Define select type
        /// </summary>
        public enum SelectType
        {
            SelectByIndex,
            SelectByText,
            SelectByValue,
        }

        /// <summary>
        /// This method is use for select option from dropdown list or combobox
        /// </summary>
        /// <param name="element"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        public static void Select(IWebElement element, SelectType type, string options)
        {
            try
            {
                SelectElement select = new SelectElement(element);
                switch (type)
                {
                    case SelectType.SelectByIndex:
                        try
                        {
                            select.SelectByIndex(Int32.Parse(options));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            throw new ArgumentException("Please input numberic on selectOption for SelectType.SelectByIndex");
                        }
                        break;
                    case SelectType.SelectByText:
                        select.SelectByText(options);
                        break;
                    case SelectType.SelectByValue:
                        select.SelectByValue(options);
                        break;
                    default:
                        throw new Exception("Get error in using Selected");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method use for Driver title of page
        /// </summary>
        /// <returns></returns>
        public static string GetTitle()
        {
            try
            {
                return BrowserFactory.Driver.Title;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Get text of element
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetText(IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This method use for clear any text on text field
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
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
