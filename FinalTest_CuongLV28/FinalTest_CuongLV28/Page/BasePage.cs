using System;
using OpenQA.Selenium;

namespace FinalTest_CuongLV28.Page
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    } 
}
