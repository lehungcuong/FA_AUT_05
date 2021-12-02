using OpenQA.Selenium;
using WebDriver;
using XunitPOM.Constants;

namespace XunitPOM.Pages
{
    public class FlightPage : BasePage
    {
        public FlightPage(IWebDriver Driver) : base(Driver) { }

        // Elements
        private IWebElement TxtSearchForBestFlight => BrowserFactory.FindElement(By.CssSelector("h2.text-center"));
        private IWebElement TxtFlyingFrom => BrowserFactory.FindElement(By.XPath("//div[@id='onereturn']//input[@name='from']"));
        private IWebElement TxtToDestination => BrowserFactory.FindElement(By.XPath("//div[@id='onereturn']//input[@name='to']"));
        private IWebElement TxtDepartureDate => BrowserFactory.FindElement(By.XPath("//div[@id='onereturn']//input[@name='depart']"));
        private IWebElement BtnFlightSearch => BrowserFactory.FindElement(By.CssSelector("button[id='flights-search']"));

        // Actions
        public bool ValidateWebOpenSuccess()
        {
            if (TxtSearchForBestFlight.Text == "SEARCH FOR BEST FLIGHTS")
            { return true; }
            return false;
        }

        public void InputSearchFlight()
        {
            BrowserFactory.setText(TxtFlyingFrom, DataConstant.FlyingFrom);
            BrowserFactory.setText(TxtToDestination, DataConstant.FlyingDestination);
            BrowserFactory.setText(TxtDepartureDate, DataConstant.DepartureDate);
        }

        public FlightSearchPage ClickOnSearchFlight()
        {
            BtnFlightSearch.Click();
            return new FlightSearchPage(driver);
        }

    }
}
