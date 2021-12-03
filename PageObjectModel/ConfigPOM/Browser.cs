using System;
using System.IO;
using static ConfigPOM.Webdriver.Browser;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading;

namespace ConfigPOM.Webdriver
{
    public class Browser 
    {
  
        public enum BrowserType
        {
            Chrome, FireFox
        }
    }
    public class BrowserFactory
    {
        public IWebDriver Driver;
        public BrowserFactory(BrowserType Type)
        {
            Driver = GetWebDriver(Type);
            
        }
        public static IWebDriver  GetWebDriver(BrowserType type)
        {
            IWebDriver driver = null;
            string driverFolder = $@"{Directory.GetCurrentDirectory()}\Webdriver\{$"{type}"}";

            switch (type)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("start - maximized");
                    driver = new ChromeDriver(driverFolder, options);
                    break;

                case BrowserType.FireFox:
                    driver = new FirefoxDriver(driverFolder);

                    break;

                default: throw new Exception("Please enter correct driver");

            }
            driver.Url = "https:phptravels.net/";
            return driver;
        }

        public IJavaScriptExecutor Jse;

        public static void KeyWord()
        {
            throw new NotImplementedException();
        }

        public void KeyWord(IWebDriver driver)
        {
            Driver = driver;
        }

        public string Getitle() => Driver?.Title;

        public IWebElement GetElement(By by) => Driver?.FindElement(by);

        public IList<IWebElement> GetListElement(By by) => (IList<IWebElement>)(Driver?.FindElement(by));

        public void ClickElement(string xpath) => GetElement(By.XPath(xpath)).Click();


        public void SendValue(string xpath, string value)
        {
            ClearValue(xpath);
            GetElement(By.XPath(xpath)).SendKeys(value);
        }

        public void SelecValueDropDown(string xpath, string value)
        {
            var selectValue = new SelectElement(GetElement(By.XPath(xpath)));
            selectValue.SelectByValue(value);
        }

        public void ClearValue(string xpath) => GetElement(By.XPath(xpath)).Clear();

        public IWebElement MovetoElement(string xpath, int position)
        {
            IWebElement element = GetListElement(By.XPath(xpath)).ElementAt(position);
            Jse.ExecuteScript("arguments[0].scrollIntoView(false);", element);
            Thread.Sleep(500);
            return element;
        }

        public void ClickElementInList(string xpath, int position) => MovetoElement(xpath, position).Click();
        public string GetTextInElement(string xpath) => GetElement(By.XPath(xpath)).Text;



    }
}
