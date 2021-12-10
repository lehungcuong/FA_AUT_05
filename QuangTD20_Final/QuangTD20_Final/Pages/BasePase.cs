using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace QuangTD20_Final.Pages
{
    class BasePase
    {
        public readonly IWebDriver Driver;
        public BasePase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
