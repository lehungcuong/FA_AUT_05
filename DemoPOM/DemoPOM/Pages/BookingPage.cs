using OpenQA.Selenium;
using Project1.WebDriver;

namespace DemoPOM.Pages
{
    public class BookingPage : BasePage
    {
        public BookingPage(Browser browser) : base(browser)
        {

        }

        IWebElement BtnBooking => Browser.GetElement(By.XPath("//button[@id ='flights-search']"));
        IWebElement bookingPageTitle => Browser.GetElement(By.XPath(""));

        public void NavigatePageSuccess(string pageTitle, IWebDriver driver)
        {
            Browser.ValidateWebTitle(pageTitle, driver);
        }

        //public bool NavigatePageSuccess()
        //{
        //    return Browser.ValidateWebTitle("Flights - PHPTRAVELS", );
        //}

        public ConfirmBookingPage NavigateToConfirmBookingpage()
        {
            Browser.ClickToElement(BtnBooking);
            return new ConfirmBookingPage(browser);
        }
    }
}
