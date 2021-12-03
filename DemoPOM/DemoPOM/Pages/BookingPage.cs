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

        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }

        public ConfirmBookingPage NavigateToConfirmBookingpage()
        {
            Browser.ClickToElement(BtnBooking);
            return new ConfirmBookingPage(browser);
        }
    }
}
