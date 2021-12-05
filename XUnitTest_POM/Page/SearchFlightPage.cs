using OpenQA.Selenium;
using XUnitTest_POM_Webdriver;

namespace XUnitTest_POM.Page
{
    class SearchFlightPage : BasePage
    {
        public SearchFlightPage(IWebDriver driver) : base() { }

        #region Elements on Search Flight page
        IWebElement TxtFlyingFrom => BrowserFactory.FindElement("//input[@id='autocomplete']");
        IWebElement TxtToDestination => BrowserFactory.FindElement("//input[@id='autocomplete2']");
        IWebElement TxtDepartureDate => BrowserFactory.FindElement("//input[@id='departure' and contains(@class,'depart')]");
        IWebElement BtnSearch => BrowserFactory.FindElement("//button[@id='flights-search']");
        #endregion

        /// <summary>
        /// Verify Flights page title
        /// </summary>
        public static bool VerifyFlightsPageTitle => BrowserFactory.GetTitle().Equals("Search Hotels - PHPTRAVELS");

        /// <summary>
        /// Choose a Flight
        /// </summary>
        public void ChooseFlight()
        {
            BrowserFactory.SendKeys(TxtFlyingFrom, "DUB");
            BrowserFactory.SendKeys(TxtToDestination, "LCG");
            BrowserFactory.SendKeys(TxtDepartureDate, "27-11-2021");
            BrowserFactory.ClickElement(BtnSearch);
        }
    }
}
