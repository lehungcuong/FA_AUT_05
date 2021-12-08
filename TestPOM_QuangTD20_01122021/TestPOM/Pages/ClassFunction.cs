using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestPOM.Pages
{
    class ClassFunction
    {

        

        public static void WebElementinput(IWebElement element, string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch(Exception notinputelement)
            {
                Console.WriteLine("not input [0] in [1]",text,element);
                throw;
            }
        }


        public static void WebElementClick(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception notclickelementE)
            {
                Console.WriteLine("error not click in element " + element);
                throw;
            }
            
        }
        public static void WebElementClear(IWebElement element)
        {
            try
            {
                element.Clear();
            }
            catch (Exception notclearelement)
            {
                Console.WriteLine("error not clear text in element "+ element);
                throw;
            }
            
        }

        public static void ScrollWindowBrowser(IWebDriver driver, int x)
        {
            try
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript($"scroll(0, {x});");
            }
            catch (Exception notScroolelement)
            {
                Console.WriteLine("Error Scroll page");
                throw;
            }
           
        }


    }
}
