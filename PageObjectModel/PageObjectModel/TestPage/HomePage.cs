using System;
using ConfigPOM.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace PageObjectModel.TestPage
{
    public class HomePage : BasePage
    {
        

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        
        IWebElement BtnFlight => Driver.FindElement(By.XPath("//a[@href='https://phptravels.net/flights']"));
        
        public void GotoFlightBooking()
        {
            BtnFlight.Click();
        }
    }
}
