using OpenQA.Selenium;
using Project1.WebDriver;
using System;

namespace DemoPOM.Pages
{
    public class BasePage 
    {
        
        public Browser browser;
        public BasePage(Browser browser)
        {
            this.browser = browser;
        }

        public void Dispose()
        {
            Browser.Driver.Close();
            Browser.Driver.Quit();
        }
    }



}

