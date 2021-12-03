using OpenQA.Selenium;
using Project1.WebDriver;

namespace DemoPOM.Pages
{
    public class FlightPage : BasePage
    {
        public FlightPage(Browser browser) : base(browser)
        {

        }

        //Enter flight information
        IWebElement BtnSearch => Browser.GetElement(By.XPath("//button[@id='flights-search']"));
        IWebElement TxtFlightFrom => Browser.GetElement(By.XPath("//input[@id='autocomplete']"));
        IWebElement TxtDestination => Browser.GetElement(By.XPath("//input[@id='autocomplete2']"));
        IWebElement TxtDateTime => Browser.GetElement(By.XPath("(//input[@id='departure'])[1]"));


        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle("Search Hotels - PHPTRAVELS");
        }

        public void InputFlightInformation(string from, string to, string date)
        {
            Browser.EnterText(TxtFlightFrom, from);
            Browser.EnterText(TxtDestination, to);
            Browser.EnterText(TxtDateTime, date);
        }

        public void InputFlightInformation1()
        {
            Browser.EnterText(TxtFlightFrom, "DUB");
            Browser.EnterText(TxtDestination, "LCG");
            Browser.EnterText(TxtDateTime, "04-12-2021");
        }

        public BookingPage ClickToSearchButton()
        {
            Browser.ClickToElement(BtnSearch);            
            return new BookingPage(browser);
        }
    }
}
