using OpenQA.Selenium;
using Project1.WebDriver;

namespace DemoPOM.Pages
{
    public class BookingSuccessPage : BasePage
    {
        IWebElement bookingSuccessPageTitle => Browser.GetElement(By.XPath(""));
        public BookingSuccessPage(Browser browser) : base(browser)
        {

        }

        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }

    }
}
