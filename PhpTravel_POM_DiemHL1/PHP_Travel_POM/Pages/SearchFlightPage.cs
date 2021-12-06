using OpenQA.Selenium;

namespace PHP_Travel_POM.Pages
{
    public class SearchFlightPage : BasePage
    {
        public SearchFlightPage(IWebDriver driver) : base(driver)
        {
        }

        //Element for search Flight Page
        IWebElement BtnFlightsFrom => Driver.FindElement(By.XPath("//input[@id='autocomplete']"));
        IWebElement BtnToDestination => Driver.FindElement(By.XPath("//input[@id='autocomplete2']"));
        IWebElement BtnDepartureDate => Driver.FindElement(By.XPath("//div[@id='onereturn']//input[@id='departure']"));
        IWebElement BtnSearch => Driver.FindElement(By.XPath("//button[@id='flights-search']"));
        IWebElement BtnBookNow => Driver.FindElement(By.XPath("//li[1]//button"));


        //Action for search Flight Page
        public void TxtSearchFlight()
        {
            BtnFlightsFrom.SendKeys("DUB");
            BtnToDestination.SendKeys("LCG");
            BtnDepartureDate.Clear();
            BtnDepartureDate.SendKeys("4-12-2021");
        }

        public void ClickOnSearchFlight()
        {
            BtnSearch.Click();
        }

        public void ClickOnBookNow()
        {
            BtnBookNow.Click();
        }
    }
}
