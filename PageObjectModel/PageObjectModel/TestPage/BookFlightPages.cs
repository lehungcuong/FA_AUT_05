using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectModel.TestPage
{
    public class BookFlightPages : BasePage
    {
        public BookFlightPages(IWebDriver driver) : base(driver)
        {

        }

            IWebElement TxtFlying => Driver.FindElement(By.XPath("//input[@placeholder='Flying From']"));
            IWebElement TxtDestination => Driver.FindElement(By.XPath("//input[@id='autocomplete2']"));
            IWebElement TxtDate => Driver.FindElement(By.XPath("//input[@id='departure' and @class='depart form-control']"));
            IWebElement TxtPassenger => Driver.FindElement(By.XPath("//a[@role='button']"));
            IWebElement BtnSearch => Driver.FindElement(By.XPath("//button[@id='flights-search']"));
        

        public void InputBookingFlightValues()
        {
            TxtFlying.SendKeys("DUB");
            TxtDestination.SendKeys("LCG");
            TxtDate.Clear();
            TxtDate.SendKeys("27-11-2021");
            TxtPassenger.SendKeys("1");
            BtnSearch.Click();

        }
        

    
    }

    
}
