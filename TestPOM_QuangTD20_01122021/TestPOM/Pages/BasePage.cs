using System;
using Xunit;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestPOM.Pages
{
    public class BasePage
    {
        public readonly IWebDriver Driver;
    public BasePage(IWebDriver driver)
        {
            Driver = driver;

        }
    }
}
