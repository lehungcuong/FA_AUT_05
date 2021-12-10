using Project1.WebDriver;

namespace FinalTest.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(Browser browser) : base(browser)
        {
        }

        // Check if the page redirected to orderconfirmation page
        public void NavigatePageSuccess(string pageTitle)
        {
            Browser.ValidateWebTitle(pageTitle);
        }
    }
}
