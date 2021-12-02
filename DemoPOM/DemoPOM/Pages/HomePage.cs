using OpenQA.Selenium;
using Project1.WebDriver;


namespace DemoPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(Browser browser) : base(browser)
        {           
        }

        IWebElement BtnFlight => Browser.GetElement(By.XPath("//a[@href='https://phptravels.net/flights']"));
        IWebElement homePageTitle => Browser.GetElement(By.XPath(""));

        public void NavigatePageSuccess(string pageTitle, IWebDriver driver)
        {
            Browser.ValidateWebTitle(pageTitle, driver);
        }

        //public static bool NavigateHomePageSuccess()
        //{
        //    return Browser.NavigatePageSuccess("PHPTRAVELS - PHPTRAVELS", );
        //}

        public FlightPage NavigateToFlightPage()
        {
            Browser.ClickToElement(BtnFlight); 
            return new FlightPage(browser);
        }
    }
}
