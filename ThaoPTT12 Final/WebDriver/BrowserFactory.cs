using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriver
{
    public class BrowserFactory
    {
        public IWebDriver Driver;

        public BrowserFactory(BrowserType type, string url)
        {
            Driver = GetWebDriver(type, url);
        }

        public enum BrowserType
        {
            Chrome, Firefox
        }
        public static IWebDriver GetWebDriver(BrowserType type, string url)
        {
            IWebDriver Driver;

            string pathfolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string fullPathfile = pathfolder + @"\TestProject.WebDriver\WebDriver\" + $"{type}";

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            switch (type)
            {
                case BrowserType.Chrome:
                    Driver = new ChromeDriver(fullPathfile, options);
                    break;
                case BrowserType.Firefox:
                    Driver = new FirefoxDriver(fullPathfile);
                    break;
                default:
                    throw new Exception("Please enter correct driver");
            }
            //Drive navigate -> url tu  file confic
            Driver.Url = url;
            return Driver;
        }
    }
}
