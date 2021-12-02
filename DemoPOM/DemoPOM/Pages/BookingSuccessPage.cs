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

        //public bool NavigatePageSuccess()
        //{
        //    return Browser.ValidateWebTitle("Flight Invoice - PHPTRAVELS" );
        //}

        public void NavigatePageSuccess(string pageTitle, IWebDriver Driver)
        {
            Browser.ValidateWebTitle(pageTitle, Driver);
        }

    }
}
