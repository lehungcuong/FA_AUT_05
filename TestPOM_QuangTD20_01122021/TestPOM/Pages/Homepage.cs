using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace TestPOM.Pages
{
    class Homepage : BasePage
    {

        public Homepage(IWebDriver driver) : base(driver)
        {

        }
        
        //private string Result;
        public IWebElement ButtonFlights => Driver.FindElement(By.XPath("//a[@href='https://phptravels.net/flights'] "));
        
        public IWebElement ButtonTours => Driver.FindElement(By.XPath("//a[@href='https://phptravels.net/tours'] "));
       


        public void bntflights()
        {
            
            
            Driver.Manage().Window.Maximize();
            //Assert.True(Driver.Url.Equals(HomepageUrl));
            ButtonFlights.Click();
            
            Assert.True(Driver.Title == "Search Hotels - PHPTRAVELS");
        }
        public void bnttours()
        {
            string HomepageUrl = "https://phptravels.net/";
            string sd = Driver.Url;
            Driver.Manage().Window.Maximize();
            Assert.True(Driver.Url.Equals(HomepageUrl));
            //click button tours
            ButtonTours.Click();
            
            Assert.True(Driver.Title == "Search Tours - PHPTRAVELS");
        }

    }
}
