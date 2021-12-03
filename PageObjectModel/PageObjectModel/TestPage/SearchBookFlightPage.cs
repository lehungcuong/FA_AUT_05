using System;
using OpenQA.Selenium;

namespace PageObjectModel.TestPage
{
    public class SearchBookFlightPage : BasePage
    {


        public SearchBookFlightPage(IWebDriver driver) : base(driver)
        {
        }
        IWebElement BtnBook => Driver.FindElement(By.XPath("//ul[@class='catalog-panel']/*[2]//button"));

        public void ChooseTicketFlight()
        {
            BtnBook.Click();
        }
    }

}
