using System;
using OpenQA.Selenium;

namespace PageObjectModel.TestPage
{
    public class BasePage 
    {
        public IWebDriver Driver;
        
        
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            //Browser.KeyWord(Driver);


        }

      
    }
}
